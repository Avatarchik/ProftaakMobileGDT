using System;
using System.Collections.Generic;

namespace RandomEventGenerator
{
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

        public class Choice
        {
            public PlayerSkill Skill { get; private set; }
            public List<ChoiceAction> Actions { get; private set; }
            public string Text { get; private set; }
            public float Percentage { get; private set; }
            public float Min { get; private set; }
            public float Max { get; private set; }

            public Choice(string text, List<ChoiceAction> actions, PlayerSkill skill, float min, float max)
            {
                this.Text = text;
                this.Actions = actions;
                this.Min = min;
                this.Max = max;
                this.Skill = skill;
            }

            public Choice(string text, List<ChoiceAction> actions, PlayerSkill skill, float percentage, float min, float max)
            {
                this.Text = text;
                this.Actions = actions;
                this.Percentage = percentage;
                this.Min = min;
                this.Max = max;
                this.Skill = skill;
            }

            public Choice(string text, List<ChoiceAction> actions)
            {
                this.Text = text;
                this.Actions = actions;
            }
        }

        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease, FollowerIncrease, Ok, NewLightbulbNear, VisitUrl, Tutorial }

            public ActionType Action { get; private set; }

            public ChoiceAction(ActionType action)
            {
                this.Action = action;
            }
        }
    }
}