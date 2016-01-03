using System.Collections.Generic;

namespace RandomEventGenerator
{
    public class ChoiceEvent : RandomEvent
    {
        public List<Choice> Choices;

        public ChoiceEvent()
        {
            Choices = new List<Choice>();
        }
    }
}