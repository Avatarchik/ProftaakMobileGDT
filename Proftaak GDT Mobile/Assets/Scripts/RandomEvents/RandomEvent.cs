namespace Assets.Scripts.RandomEvents
{
    using System.Collections.Generic;

    public class RandomEvent
    {
        public enum RandomEventType { Info, Feitje, Keuze, Link }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TedUrl { get; set; }

        public List<Choice> Choices;


        public RandomEventType EventType;

        public Dictionary<Choice, RandomEvent> FollowUpRandomEvents;

        // TODO: Choices

        public enum ChoiceType { SkillIncrease };

        public class Choice
        {
            public string Text { get; private set; }
            public ChoiceType Type { get; private set; }
            public float Percentage { get; private set; }
            public float Min { get; private set; }
            public float Max { get; private set; }
            public PlayerSkill Skill { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Object"/> class.
            /// </summary>
            public Choice(string pText, ChoiceType type, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Type = type;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Object"/> class.
            /// </summary>
            public Choice(string pText, ChoiceType pType, float pPercentage, float pMin, float pMax, PlayerSkill pSkill)
            {
                this.Text = pText;
                this.Type = pType;
                this.Percentage = pPercentage;
                this.Min = pMin;
                this.Max = pMax;
                this.Skill = pSkill;
            }

            // result
        }


    }
}
