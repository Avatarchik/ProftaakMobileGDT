namespace Assets.Scripts.RandomEvents
{
    using UnityEngine;
    using Assets.Scripts.Managers;

    public class RandomEventBalloon : Balloon
    {
        public override void OnButtonClicked()
        {
            Debug.Log("Button clicked on RandomEventBalloon");
			
			RandomEventsManager.Instance.ShowRandomEventsCanvas();
            this.DisableBalloon();
        }
    }
}
