namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;

    public class RandomEventBalloon : Balloon
    {

        public override void OnButtonClicked()
        {
			RandomEventsManager.Instance.ShowRandomEventsCanvas();
            this.DisableBalloon();

        }

    }
}
