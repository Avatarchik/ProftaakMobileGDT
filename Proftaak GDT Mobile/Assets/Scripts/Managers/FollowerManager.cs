namespace Assets.Scripts.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Followers;
    using UnityEngine;
    using UnityEngine.UI;

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

        [SerializeField]
        private FollowerGroup _firstFollowerGroup;

        private List<int> _followerEhancementThresholds;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            this.SetupFollowerEnhancementTresholds();
            this.InvokeRepeating("IncreaseFollowers", 0f, 0.5f);
        }

        private void SetupFollowerEnhancementTresholds()
        {
            this._followerEhancementThresholds = new List<int>
            {
                500, 1500, 5000, 15000, 50000,150000, 500000,1500000, 5000000, 15000000
            };
        }
        public void StartFollowers()
        {
            this._firstFollowerGroup.gameObject.SetActive(true);
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
            // TODO: Fix magic numbers
            int knowledgeSkills = Player.Instance.KnowledgeSkills;
            foreach (FollowerGroup fg in this.FollowerGroups)
            {
                fg.Followers += 1 + (knowledgeSkills * 2)
                    + (int)((fg.Followers * 0.005f) + (fg.Followers * 0.005f * knowledgeSkills));
            }
            if (this._followerEhancementThresholds.Count > 0)
                if (this.TotalFollowers >= this._followerEhancementThresholds[0])
                {
                    Player.Instance.UnusedSkillPoints++;
                    AudioManager.Instance.PlayUpgradesAvailable();
                    this._followerEhancementThresholds.RemoveAt(0);
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
