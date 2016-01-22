using System;
using System.Collections.Generic;

namespace Assets.Scripts.RandomEvents
{
    using System.Linq;

    [Serializable]
    public class RandomEvent
    {
        public enum RandomEventType { Info, Fact, Choice, Link }

        public IdeaCategory IdeaCategory;
        public RandomEventType Type;
        public List<Choice> Choices;
        public bool HasFollowUpEvent;
        public string Title;
        public string Description;
        public string TedUrl;

        public RandomEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RandomEvent"/> class.
        /// </summary>
        public RandomEvent(RandomEventType type, List<Choice> choices, string title, string description)
        {
            this.Type = type;
            this.Choices = choices;
            this.Title = title;
            this.Description = description;
        }

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
            public List<ChoiceAction> Actions;
            public string Text;

            public Choice(string text, List<ChoiceAction> actions)
            {
                this.Text = text;
                this.Actions = actions;
            }

            public override string ToString()
            {
                return this.Text + this.Actions.Aggregate("", (lvCurrent, ca) => lvCurrent + ca.ToString());
            }
        }

        [Serializable]
        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease = 0, FollowerIncrease = 1, Ok = 2, NewLightbulbNear = 3, VisitUrl = 4, Tutorial = 5 }

            public ActionType Action;
            public object[] Values;
            public string JSONString;

            public ChoiceAction()
            {
            }

            public ChoiceAction(ActionType action)
            {
                this.Action = action;
            }

            public ChoiceAction(ActionType skillIncrease, params object[] values)
            {
                this.Action = skillIncrease;
                this.Values = values;
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
