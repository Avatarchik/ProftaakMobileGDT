﻿namespace Assets.Scripts.Enhancements
{
    using Managers;
    using System;
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

        [SerializeField]
        private Sprite _regularImage;
        [SerializeField]
        private Sprite _unlockedImage;

        [HideInInspector]
        [SerializeField]
        private List<Enhancement> _requiredEnhancements;
        private readonly List<Enhancement> _unlockableEnhancements = new List<Enhancement>();

        private Button _unlockButton;
        private Image _buttonImage;

        public bool Orderable { get; set; }


        public void Awake()
        {
            this._unlockButton = this.GetComponent<Button>();
            this._buttonImage = this.GetComponent<Image>();
            //this.GetComponentInChildren<Text>().text = this.NameAsString;
            foreach (Enhancement eh in this._requiredEnhancements)
                eh._unlockableEnhancements.Add(this);

            EnhancementData.Instance.Enhancements.Add(this);
        }

        public void UpdateStatus()
        {
            if (this.Unlocked)
            {
                this._unlockButton.interactable = true;
                this._buttonImage.sprite = this._unlockedImage;
            }
            else if (this._requiredEnhancements.Count == 0)
            {
                this._unlockButton.interactable = true;
                this._buttonImage.sprite = this._regularImage;
            }
            else if (this._requiredEnhancements.TrueForAll(x => x.Unlocked))
            {
                this._unlockButton.interactable = true;
                this._buttonImage.sprite = this._regularImage;
            }
            else
            {
                this._unlockButton.interactable = false;
                this._buttonImage.sprite = EnhancementData.Instance.LockedImg;
            }
        }

        public void EnhancementButtonClicked()
        {
            if (this.Unlocked || Player.Instance.UnusedSkillPoints < 1) return;
            this.RequiredPoints--;
            Player.Instance.UnusedSkillPoints--;
            if (this.RequiredPoints > 0) return;
            AudioManager.Instance.PlayUpgradeDone();
            this.Unlocked = true;
            Player.Instance.UnlockedEnhancements.Add(this);
            this.UpdateStatus();
            foreach (Enhancement eh in this._unlockableEnhancements)
                eh.UpdateStatus();
            this.DoEnhancement();
        }

        private void DoEnhancement()
        {
            switch (this.Name)
            {
                case EnhancementType.Houding:
                case EnhancementType.Stem:
                case EnhancementType.Handgebaren:
                    // Houding = 1, Stem = 2, Handgebaren = 3
                    Player.Instance.PresentationSkills += (int)this.Name + 1;
                    break;
                case EnhancementType.Video:
                case EnhancementType.Camera:
                case EnhancementType.Microfoon:
                    // Video = 1, Camera = 2, Microfoon = 3
                    Player.Instance.MediaSkills += (int)this.Name - (int)EnhancementType.Video + 1;
                    break;
                case EnhancementType.Papieren:
                case EnhancementType.Onderzoek:
                case EnhancementType.Experiment:
                    Player.Instance.KnowledgeSkills += (int)this.Name - (int)EnhancementType.Papieren + 1;
                    break;
                case EnhancementType.TEDx:
                    Player.Instance.KnowledgeSkills += 5;
                    Player.Instance.MediaSkills += 5;
                    Player.Instance.PresentationSkills += 5;
                    FollowerManager.Instance.TotalFollowers = 17000000;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Setup()
        {
            /* Unused, but added for OrderManager, but in project settings you can change Script Execution Order*/
        }
    }
}
