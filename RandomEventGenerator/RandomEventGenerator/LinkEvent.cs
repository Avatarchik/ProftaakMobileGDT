namespace RandomEventGenerator
{
    public enum Topics
    {
        Technology,
        Entertainment,
        Design,
        Business,
        Science,
        GlobalIssues
    }

    public class LinkEvent : RandomEvent
    {
        public Topics Topic;
        public string SpeakerName;
        public string EventName;
        public string Url;
    }
}