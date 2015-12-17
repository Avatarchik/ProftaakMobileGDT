namespace Assets.Scripts.RandomEvents
{
    using System.Collections.Generic;

    public class RandomEvent
    {
        public enum RandomEventType { Info, Feitje, Keuze, Link }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TedUrl { get; set; }


        // TODO: Choices
        /*
            
            class Choice : RandomEvent
            {
                public float min;
                public float max;
                public string skill;
            }

            o.i.d.

       */

        public RandomEventType EventType;

        public List<RandomEvent> Children;
    }
}
