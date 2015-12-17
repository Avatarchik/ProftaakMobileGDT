namespace Assets.Scripts.Followers
{
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Scripts.Helpers;

    using UnityEngine;

    public class FollowerManager : MonoBehaviour
    {
        public static FollowerManager Instance = new FollowerManager();


        public List<FollowerGroup> FollowerGroups;

        public int TotalFollowers { get { return this.FollowerGroups.IsNullOrEmpty() ? 0 : this.FollowerGroups.Count; } }


        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            this.InvokeRepeating("IncreaseFollowers", 0f, Random.Range(0.25f, 0.5f));
        }

        // ReSharper disable once UnusedMember.Local
        private void IncreaseFollowers()
        {
            // TODO: Fix magic numbers
            foreach (FollowerGroup fg in this.FollowerGroups.Where(fg => Random.Range(0, 4) > 2))
                fg.Followers += Random.Range(5, 20);
        }
    }
}
