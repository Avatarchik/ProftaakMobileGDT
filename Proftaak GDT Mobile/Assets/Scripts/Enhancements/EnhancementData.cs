namespace Assets.Scripts.Enhancements
{
    using System.Collections.Generic;
    using UnityEngine;

    public class EnhancementData : MonoBehaviour, IOrderable
    {
        public static EnhancementData Instance;
        
        public Sprite RegularImg;
        public Sprite UnlockedImg;
        public Sprite LockedImg;

        public readonly List<Enhancement> Enhancements = new List<Enhancement>(); 

        public bool Orderable { get; set; }

        public void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            foreach (Enhancement eh in this.Enhancements)
                eh.UpdateStatus();
        }


        public void Setup()
        {
            // Unused, but added for OrderManager, but in project settings you can change Script Execution Order
        }
    }
}
