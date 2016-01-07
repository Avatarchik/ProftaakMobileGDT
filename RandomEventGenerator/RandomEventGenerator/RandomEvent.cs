using System.Collections.Generic;

namespace RandomEventGenerator
{
	public enum PlayerSkill { Knowledge, Presentation, Media }
	
    public class RandomEvent
    {
        public enum RandomEventType { Info, Fact, Choice, Link }

        public RandomEventType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TedUrl { get; set; }

        public List<Choice> Choices;

        public Dictionary<Choice, RandomEvent> FollowUpRandomEvents;

        public class Choice
        {
            public enum ChoiceType { SkillIncrease }

            public ChoiceType Type { get; private set; }
            public string Text { get; private set; }
            public float Percentage { get; private set; }
            public float Min { get; private set; }
            public float Max { get; private set; }

            public PlayerSkill Skill { get; private set; }

            public Choice(string pText, ChoiceType type, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Type = type;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }

            public Choice(string pText, ChoiceType pType, float pPercentage, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Type = pType;
                this.Percentage = pPercentage;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }
        }
    }
}
