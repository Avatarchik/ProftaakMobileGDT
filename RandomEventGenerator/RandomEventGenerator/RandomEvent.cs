using System;
using System.Collections.Generic;

namespace RandomEventGenerator
{
    using System.Linq;

    public enum PlayerSkill { Knowledge = 0, Presentation = 1, Media = 2 }

    [Serializable]
    public class RandomEvent
    {
        public enum RandomEventType { Info, Fact, Choice, Link }

        public RandomEventType Type { get; set; }
        public List<Choice> Choices { get; set; }
        public Dictionary<Choice, RandomEvent> FollowUpRandomEvents { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TedUrl { get; set; }

        public void SetChoiceActionValues()
        {
            if (this.Choices == null)
                return;

            foreach (ChoiceAction ca in this.Choices.SelectMany(c => c.Actions))
                ca.SetValues();
        }

        [Serializable]
        public class Choice
        {
            public List<ChoiceAction> Actions { get; private set; }
            public string Text { get; private set; }

            public Choice(string text, List<ChoiceAction> actions)
            {
                this.Text = text;
                this.Actions = actions;
            }

            public override string ToString()
            {
                return this.Text + this.Actions.Aggregate(", ", (lvCurrent, ca) => lvCurrent + ca.ToString()).Remove(0, 2);
            }
        }

        [Serializable]
        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease = 0, FollowerIncrease = 1, Ok = 2, NewLightbulbNear = 3, VisitUrl = 4, Tutorial = 5 }

            public ActionType Action;

            public object[] Values { get; set; }

            public string JSONString;

            // used for JSON
            public ChoiceAction()
            {

            }

            public ChoiceAction(ActionType action, string JSONString)
            {
                this.Action = action;
                this.JSONString = JSONString;
            }

            public ChoiceAction(ActionType action)
            {
                this.Action = action;
            }

            public void SetValues()
            {
                if (this.JSONString == null)
                    return;

                string[] values = this.JSONString.Split(';');

                switch (this.Action)
                {
                    case ActionType.SkillIncrease:
                        List<object> skillValues = new List<object>();
                        PlayerSkill skill = (PlayerSkill)Convert.ToInt32(values[0]);
                        int number = Convert.ToInt32(values[1]);
                        skillValues.Add(skill);
                        skillValues.Add(number);
                        if (values.Length > 3)
                        {
                            PlayerSkill skillFactor = (PlayerSkill)Convert.ToInt32(values[2]);
                            skillValues.Add(skillFactor);
                            int factorSkill = Convert.ToInt32(values[3]);
                            skillValues.Add(factorSkill);
                        }
                        this.Values = skillValues.ToArray();
                        break;
                    case ActionType.FollowerIncrease:
                        List<object> followerValues = new List<object>();
                        int followers = Convert.ToInt32(values[0]);
                        followerValues.Add(followers);
                        if (values.Length > 2)
                        {
                            PlayerSkill playerSkill = (PlayerSkill)Convert.ToInt32(values[1]);
                            followerValues.Add(playerSkill);
                            int factor = Convert.ToInt32(values[2]);
                            followerValues.Add(factor);
                        }
                        this.Values = followerValues.ToArray();
                        break;
                    case ActionType.Ok:
                        break;
                    case ActionType.NewLightbulbNear:
                        bool shouldRespawn;
                        int boolRespawn;
                        if (int.TryParse(values[0], out boolRespawn))
                            shouldRespawn = Convert.ToBoolean(boolRespawn);
                        else
                            shouldRespawn = Convert.ToBoolean(values[0]);
                        this.Values = new object[] { shouldRespawn };
                        break;
                    case ActionType.VisitUrl:
                        this.Values = new object[] { values[0] };
                        break;
                    case ActionType.Tutorial:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public override string ToString()
            {
                if (this.Values != null)
                    return this.Action + ": " + this.Values.ArrayToString();
                if (this.JSONString != null)
                    return this.Action + ": " + this.JSONString;
                return this.Action.ToString();
            }
        }
    }
}