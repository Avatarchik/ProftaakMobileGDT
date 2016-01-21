namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;
    using UnityEngine;

    public class LightbulbBalloon : Balloon
    {
        public AudioManager am = null;

        public AudioClip aC;

        public override void OnButtonClicked()
        {
            if (am != null)
            {
                am.PlayButtonClick(aC);
            }
            FollowerManager.Instance.CreateNewFollowerGroup(new Vector2(this.transform.position.x, this.transform.position.y), 100);
            this.DisableBalloon();
        }        
    }
}
