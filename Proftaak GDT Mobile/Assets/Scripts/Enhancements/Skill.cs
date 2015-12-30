using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Enhancements
{
    [RequireComponent(typeof(Button))]
    public class Skill : MonoBehaviour
    {

        public GameObject upgradeObj;
        [HideInInspector]
        public Skill[] requiredSkills;

        private Button unlockButton;

        private int _RequiredUnlocks;

        public int RequiredUnlocks
        {
            get { return this._RequiredUnlocks; }
            set
            {
                this._RequiredUnlocks = value;
                if (this._RequiredUnlocks >= this.requiredSkills.Length)
                {

                    this.unlocked = true;
                    this.unlockButton.interactable = true;
                    this.unlockButton.image.sprite = this.regularImg;
                }
            }
        }

        [HideInInspector]
        public Skill unlockSkill;


        [SerializeField]
        private IUpgrade upgrade;
        private Text upgradeName;

        [SerializeField]
        private bool upgraded;
        private bool unlocked;


        //Button Images
        public Sprite regularImg, unlockedImg, lockedImg;

        // Use this for initialization
        private void Start()
        {

            this.unlocked = false;
            this.upgraded = false;

            this.upgradeName = this.GetComponentInChildren<Text>();

            this.unlockButton = this.GetComponent<Button>();
            this.unlockButton.image.sprite = this.regularImg;

            this.upgrade = this.upgradeObj.GetComponent<IUpgrade>();
            this.upgradeName.text = this.upgrade.Name;

            foreach (Skill s in this.requiredSkills)
            {
                s.unlockSkill = this;
                //_RequiredUnlocks += 1;
            }

            if (this.requiredSkills.Length != 0)
            {
                this.unlockButton.image.sprite = this.lockedImg;
                this.unlockButton.interactable = false;

            }

        }

        public void UnlockSkill()
        {
            if (this.upgrade.Upgrade() && !this.upgraded)
            {
                Player.Instance.UnusedSkillPoints -= this.upgrade.RequiredPoints;
                this.upgraded = true;
                this.unlockButton.image.sprite = this.unlockedImg;

                if (this.unlockSkill != null)
                {
                    this.unlockSkill.RequiredUnlocks += 1;
                }
            }

        }

        // Update is called once per frame
        void Update()
        {


        }
    }
}
