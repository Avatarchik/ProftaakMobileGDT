using UnityEngine;

namespace Assets.Scripts.Followers
{
    public class FollowerGroup : MonoBehaviour {



        private int _targetFollowers = 0;

        [SerializeField]
        private int _followers;
        public int Followers { get { return this._followers; } set { this._followers = value; } }

        public float DevideBy = 10000f;
        public float StartSize = 1f;

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (this._targetFollowers == this.Followers) return;
            if (this._targetFollowers > this.Followers)
                this._targetFollowers -= (((this._targetFollowers + 1) - (this.Followers + 1)) / 5);
            else
                this._targetFollowers += (((this.Followers + 1) - (this._targetFollowers + 1)) / 5);
            this.transform.localScale = new Vector3(this.StartSize + (this._targetFollowers / this.DevideBy), this.StartSize + (this._targetFollowers / this.DevideBy), 1);
        }

    }
}
