using System;
using System.Collections.Generic;

namespace Assets.Scripts.RandomEvents
{
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
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
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

        public class Choice
        {
            public List<ChoiceAction> Actions;
            public string Text;

            public Choice(string text, List<ChoiceAction> actions)
            {
                this.Text = text;
                this.Actions = actions;
            }
        }

        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease, FollowerIncrease, Ok, NewLightbulbNear, VisitUrl, Tutorial }

            public ActionType Action;
            public object[] Values;

            public ChoiceAction(ActionType action, params object[] values)
            {
                this.Action = action;
                this.Values = values;
            }
        }
    }
}
