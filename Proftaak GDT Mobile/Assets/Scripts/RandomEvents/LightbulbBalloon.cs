namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;
    using UnityEngine;

    public class LightbulbBalloon : Balloon
    {
        public AudioClip aC;

        public override void OnButtonClicked()
        {
            AudioManager.Instance.PlayButtonClick(this.aC);
            FollowerManager.Instance.CreateNewFollowerGroup(new Vector2(this.transform.position.x, this.transform.position.y), 100);
            this.DisableBalloon();
        }
    }
}
