namespace Assets.Scripts.RandomEvents
{
    using System.Collections.Generic;

    public class RandomEvent
    {
        public enum RandomEventType { Info, Fact, Choice, Link }

        public RandomEventType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TedUrl { get; set; }

        public List<Choice> Choices;

        public Dictionary<Choice, RandomEvent> FollowUpRandomEvents;

        public class ChoiceAction
        {
            public enum ActionType { SkillIncrease, Ok, NewLightbulbNear }
            public ActionType Action { get; private set; }

            public ChoiceAction(ActionType action)
            {
                this.Action = action;
            }
        }
        public class Choice
        {
            public IList<ChoiceAction> Actions { get; private set; }
            public string Text { get; private set; }
            public float Percentage { get; private set; }
            public float Min { get; private set; }
            public float Max { get; private set; }

            public PlayerSkill Skill { get; private set; }

            public Choice(string pText, IList<ChoiceAction> actions, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Actions = actions;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }

            public Choice(string pText, IList<ChoiceAction> actions, float pPercentage, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Actions = actions;
                this.Percentage = pPercentage;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }

            public Choice(string text, IList<ChoiceAction> actions)
            {
                this.Text = text;
                this.Actions = actions;
            }
        }
    }
}
