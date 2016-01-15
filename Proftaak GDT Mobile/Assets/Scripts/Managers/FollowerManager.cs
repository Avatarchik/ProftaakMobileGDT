namespace Assets.Scripts.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Followers;
    using UnityEngine;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class FollowerManager : MonoBehaviour
    {
        public static FollowerManager Instance;


        public List<FollowerGroup> FollowerGroups;

        public int TotalFollowers
        {
            get { return this.FollowerGroups.IsNullOrEmpty() ? 0 : this.FollowerGroups.Select(x => x.Followers).Sum(); }
            set
            {
                foreach (FollowerGroup fg in this.FollowerGroups)
                {
                    fg.Followers += value / this.FollowerGroups.Count;
                }
            }
        }

        [SerializeField]
        private Text _followersText;

        [SerializeField]
        private FollowerGroup _followerGroupPrefab;

        [SerializeField]
        private Canvas _followersCanvas;


        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            this.InvokeRepeating("IncreaseFollowers", 0f, 0.5f);
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            // TODO: Misschien niet in de Update?
            this.UpdateFollowersText();
        }

        public void UpdateFollowersText()
        {
            this._followersText.text = HelperClass.ValueToStringWithSeperators(this.TotalFollowers);
        }

        // ReSharper disable once UnusedMember.Local
        private void IncreaseFollowers()
        {
            int knowledgeSkills = Player.Instance.KnowledgeSkills;
            // TODO: Fix magic numbers
            foreach (FollowerGroup fg in this.FollowerGroups.Where(fg => Random.Range(0, 4) > 2))
            {
                fg.Followers += Random.Range(5 + (knowledgeSkills * 2), 20 + (knowledgeSkills * 2))
                    + (int)((fg.Followers * 0.05) + (fg.Followers * 0.01f * knowledgeSkills));
            }
        }

        public void CreateNewFollowerGroup(Vector2 pos, int startFollowers)
        {
            FollowerGroup newGroup = GameObject.Instantiate(this._followerGroupPrefab);
            newGroup.transform.SetParent(this._followersCanvas.transform);
            //newGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
            newGroup.GetComponent<RectTransform>().position = pos;
            newGroup.Followers = startFollowers;
            this.FollowerGroups.Add(newGroup);

        }
    }
}
