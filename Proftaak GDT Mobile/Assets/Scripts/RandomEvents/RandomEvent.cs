using System;
using System.Collections.Generic;

namespace Assets.Scripts.RandomEvents
{
    using System.Linq;

    [Serializable]
    public class RandomEvent
    {
        public enum RandomEventType { Info, Fact, Choice, Link }

        public RandomEventType Type;
        public List<Choice> Choices;
        public Dictionary<Choice, RandomEvent> FollowUpRandomEvents;
        public string Title;
        public string Description;
        public string TedUrl;

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

        // gebruikt voor JSON
        public RandomEvent() { }

        public void SetChoiceActionValues()
        {
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
            public enum ActionType { SkillIncrease, FollowerIncrease, Ok, NewLightbulbNear, VisitUrl, Tutorial }

            public ActionType Action;
            public object[] Values { get; private set; }
            public string JSONString;

            // used for JSON
            public ChoiceAction()
            {

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
                        PlayerSkill skill = (PlayerSkill)Convert.ToInt32(values[0]);
                        int number = Convert.ToInt32(values[1]);
                        this.Values = new object[] { skill, number };
                        break;
                    case ActionType.FollowerIncrease:
                        int followers = Convert.ToInt32(values[0]);
                        this.Values = new object[] { followers };
                        break;
                    case ActionType.Ok:
                        break;
                    case ActionType.NewLightbulbNear:
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
