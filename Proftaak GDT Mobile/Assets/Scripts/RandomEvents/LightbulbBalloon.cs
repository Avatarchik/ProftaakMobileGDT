namespace Assets.Scripts.RandomEvents
{
    using Assets.Scripts.Managers;
    using UnityEngine;

    public class LightbulbBalloon : Balloon
    {
        public override void OnButtonClicked()
        {
            Debug.Log("Button clicked on Lightbulb balloon");
            FollowerManager.Instance.CreateNewFollowerGroup(new Vector2(this.transform.position.x, this.transform.position.y), 100);
            this.DisableBalloon();
            this.transform.position = new Vector3(this.transform.position.x - 20f, this.transform.position.y, this.transform.position.z);
        }
    }
}
