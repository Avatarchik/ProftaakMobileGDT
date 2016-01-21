namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;
    using UnityEngine;

    public class RandomEventBalloon : Balloon
    {

        public AudioManager am = null;

        public AudioClip aC;

        public override void OnButtonClicked()
        {
            if(am!= null)
            {
                am.PlayButtonClick(aC);
            }
			RandomEventsManager.Instance.ShowRandomEventsCanvas();
            this.DisableBalloon();

        }

    }
}
