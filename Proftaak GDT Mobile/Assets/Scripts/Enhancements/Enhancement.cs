namespace Assets.Scripts.Enhancements
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public enum EnhancementType { Houding, Stem, Handgebaren, Video, Camera, Microfoon, Papieren, Onderzoek, Experiment, TEDx }



    [RequireComponent(typeof(Button))]
    public class Enhancement : MonoBehaviour, IOrderable
    {
        public EnhancementType Name;
        public string NameAsString { get { return this.Name.ToString(); } }

        public uint RequiredPoints;
        public bool Unlocked;
        
        [HideInInspector]
        [SerializeField]
        private List<Enhancement> _requiredEnhancements;
        private readonly List<Enhancement> _unlockableEnhancements = new List<Enhancement>();

        private Button _unlockButton;

        public bool Orderable { get; set; }


        public void Awake()
        {
            this._unlockButton = this.GetComponent<Button>();
            this.GetComponentInChildren<Text>().text = this.NameAsString;
            foreach (Enhancement eh in this._requiredEnhancements)
                eh._unlockableEnhancements.Add(this);

            EnhancementData.Instance.Enhancements.Add(this);
        }

        public void UpdateStatus()
        {
            Debug.Log("Status updated");
            if (this.Unlocked)
            {
                this._unlockButton.interactable = true;
                this._unlockButton.image.sprite = EnhancementData.Instance.UnlockedImg;
            }
            else if (this._requiredEnhancements.Count == 0)
            {
                this._unlockButton.interactable = true;
                this._unlockButton.image.sprite = EnhancementData.Instance.RegularImg;
            }
            else if (this._requiredEnhancements.TrueForAll(x => x.Unlocked))
            {
                this._unlockButton.interactable = true;
                this._unlockButton.image.sprite = EnhancementData.Instance.RegularImg;
            }
            else
            {
                this._unlockButton.interactable = false;
                this._unlockButton.image.sprite = EnhancementData.Instance.LockedImg;
            }

        }

        public void EnhancementButtonClicked()
        {
            if (this.Unlocked || Player.Instance.UnusedSkillPoints < 1) return;
            this.RequiredPoints--;
            if (this.RequiredPoints > 0) return;
            this.Unlocked = true;
            Player.Instance.UnusedSkillPoints -= this.RequiredPoints;
            Player.Instance.UnlockedEnhancements.Add(this);
            this._unlockButton.image.sprite = EnhancementData.Instance.UnlockedImg;
            foreach (Enhancement eh in this._unlockableEnhancements)
                eh.UpdateStatus();
        }

        public void Setup() { /* Unused, but added for OrderManager, but in project settings you can change Script Execution Order*/ }

    }
}
