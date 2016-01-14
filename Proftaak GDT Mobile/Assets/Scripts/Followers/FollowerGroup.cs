using UnityEngine;

namespace Assets.Scripts.Followers
{
    public class FollowerGroup : MonoBehaviour {

        [SerializeField]
        private int _targetFollowersIncrease = 50;

        private int _targetFollowers;

        [SerializeField]
        private int _followers;
        public int Followers { get { return this._followers; } set { this._followers = value; } }

        public float DevideBy = 5000000f;
        public float StartSize = 1f;

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (this._targetFollowers == this.Followers) return;
            if (this._targetFollowers > this.Followers)
                this._targetFollowers -= (((this._targetFollowers + 1) - (this.Followers + 1)) / this._targetFollowersIncrease);
            else
                this._targetFollowers += (((this.Followers + 1) - (this._targetFollowers + 1)) / this._targetFollowersIncrease);
            this.transform.localScale = new Vector3(this.StartSize + (this._targetFollowers / this.DevideBy), this.StartSize + (this._targetFollowers / this.DevideBy), 1);
        }

    }
}
