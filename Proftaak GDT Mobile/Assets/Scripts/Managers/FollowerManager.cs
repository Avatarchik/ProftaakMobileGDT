namespace Assets.Scripts.Managers
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Helpers;
    using Followers;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    public class FollowerManager : MonoBehaviour
    {
        public static FollowerManager Instance;

        [SerializeField]
        private float _followersPerPercentage = 0.001f;
        [SerializeField]
        private float _followersPerKnowledgeSkill = 5;
        [SerializeField]
        private float _followersPerKnowledgeSkillPercentage = 0.001f;

        [SerializeField]
        private int _startFollowersForBalloon = 100;
        [SerializeField]
        private int _followersStartPerPresentationSkill = 100;
        [SerializeField]
        private float _followersStartPerPresentationSkillPercentage = 0.002f;


        public List<FollowerGroup> FollowerGroups;

        private float _time;

        public int TotalFollowers
        {
            get
            {
                if (this.FollowerGroups.IsNullOrEmpty()) return 0;
                int totalFollowers = 0;
                foreach (FollowerGroup fg in this.FollowerGroups)
                    if (fg.Followers >= Int32.MaxValue)
                        return int.MaxValue;
                    else
                    {
                        totalFollowers += fg.Followers;
                        if (totalFollowers >= int.MaxValue)
                            return int.MaxValue;
                    }
                return totalFollowers;
            }
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
            this.InvokeRepeating("IncreaseTime", 0f, 1f);
        }

        private void SetupFollowerEnhancementTresholds()
        {
            this._followerEhancementThresholds = new List<int>
            {
                500, 1500, 5000, 15000, 50000,150000, 500000,1500000, 15000000
            };
        }
        public void StartFollowers()
        {
            this._firstFollowerGroup.gameObject.SetActive(true);
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            this.UpdateFollowersText();
            if (this.TotalFollowers > 17000000)
            {
                PlayerPrefs.SetFloat("TotalTime", this._time);
                SceneManager.LoadScene("EndScreen");
            }
        }

        public void UpdateFollowersText()
        {
            this._followersText.text = HelperClass.ValueToStringWithSeperators(this.TotalFollowers);
        }

        // ReSharper disable once UnusedMember.Local
        private void IncreaseFollowers()
        {
            int knowledgeSkills = Player.Instance.KnowledgeSkills;
            int totalFromKnowledgeSkills = 0;
            int totalBase = 0;
            foreach (FollowerGroup fg in this.FollowerGroups)
            {
                totalBase += 3 + (int)(fg.Followers * this._followersPerPercentage);
                int followersFromKnowledgeSkills = (int)((knowledgeSkills * this._followersPerKnowledgeSkill)
                    + (fg.Followers * this._followersPerKnowledgeSkillPercentage * knowledgeSkills));
                totalFromKnowledgeSkills += followersFromKnowledgeSkills;
                fg.Followers += totalBase + followersFromKnowledgeSkills;
            }
            Debug.Log(string.Format("Base followers: {0} and from knowledge: {1}", totalBase, totalFromKnowledgeSkills));
            if (this._followerEhancementThresholds.Count > 0)
                if (this.TotalFollowers >= this._followerEhancementThresholds[0])
                {
                    Player.Instance.UnusedSkillPoints++;
                    AudioManager.Instance.PlayUpgradesAvailable();
                    this._followerEhancementThresholds.RemoveAt(0);
                }
        }

        public void CreateNewFollowerGroup(Vector2 pos)
        {
            FollowerGroup newGroup = GameObject.Instantiate(this._followerGroupPrefab);
            newGroup.transform.SetParent(this._followersCanvas.transform);
            //newGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
            newGroup.GetComponent<RectTransform>().position = pos;
            newGroup.Followers = this._startFollowersForBalloon + (this._followersStartPerPresentationSkill * Player.Instance.PresentationSkills)
                + (int)(this._followersStartPerPresentationSkillPercentage * Player.Instance.PresentationSkills * this.TotalFollowers);
            LogHelper.Log(typeof(FollowerManager), "start followers: " + newGroup.Followers);
            this.FollowerGroups.Add(newGroup);
        }
        public void IncreaseTime()
        {
            this._time += 1;
        }

    }
}
