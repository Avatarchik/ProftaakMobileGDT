namespace Assets.Scripts.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Followers;
    using Assets.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.UI;

    public class FollowerManager : MonoBehaviour
    {
        public static FollowerManager Instance = new FollowerManager();


        public List<FollowerGroup> FollowerGroups;

        public int TotalFollowers { get { return this.FollowerGroups.IsNullOrEmpty() ? 0 : this.FollowerGroups.Select(x => x.Followers).Sum(); } }

        [SerializeField]
        private Text _followersText;

        [SerializeField]
        private FollowerGroup _followerGroupPrefab;
        

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            this.InvokeRepeating("IncreaseFollowers", 0f, Random.Range(0.25f, 0.5f));
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            this._followersText.text = "Volgers: " + this.TotalFollowers;
        }

        // ReSharper disable once UnusedMember.Local
        private void IncreaseFollowers()
        {
            // TODO: Fix magic numbers
            foreach (FollowerGroup fg in this.FollowerGroups.Where(fg => Random.Range(0, 4) > 2))
                fg.Followers += Random.Range(5, 20);
        }

        public void CreateNewFollowerGroup(Vector2 pos, int startFollowers)
        {
            FollowerGroup newGroup = Instantiate(this._followerGroupPrefab);
            newGroup.GetComponent<RectTransform>().sizeDelta = pos;
            newGroup.Followers = startFollowers;
            this.FollowerGroups.Add(newGroup);
            
        }
    }
}
