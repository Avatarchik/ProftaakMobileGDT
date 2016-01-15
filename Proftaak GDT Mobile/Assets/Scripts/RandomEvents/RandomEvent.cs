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

        public class Choice
        {
            public PlayerSkill Skill;
            public List<ChoiceAction> Actions;
            public string Text;
            public float Percentage;
            public float Min;
            public float Max;

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

            public ActionType Action;

            public ChoiceAction(ActionType action)
            {
                this.Action = action;
            }
        }
    }
}
