using System;
using System.Collections.Generic;

namespace RandomEventGenerator
{
    using System.Linq;

    public enum PlayerSkill { Knowledge, Presentation, Media }

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
                return this.Text + this.Actions.Aggregate(", ", (lvCurrent, ca) => lvCurrent + ca.ToString()).Remove(0,2);
            }
        }

        [Serializable]

        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease, FollowerIncrease, Ok, NewLightbulbNear, VisitUrl, Tutorial }

            public ActionType Action { get; private set; }

            public int[] Values {get; set;}

            public ChoiceAction(ActionType action, params int[] values)
            {
                this.Action = action;
                this.Values = values;
            }
            
            public override string ToString()
            {
                return this.Action + ": " + this.Values.ArrayToString();
            }
        }
    }
}