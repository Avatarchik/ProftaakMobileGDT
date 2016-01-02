namespace Assets.Scripts.Managers
{
    using Assets.Scripts.Enhancements;
    using UnityEngine;
    internal class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Canvas UpgradeCanvas;

        [SerializeField]
        private Canvas UICanvas;

        public static UIManager Instance;


        public void GoToUpgradeCanvas()
        {
            this.UpgradeCanvas.gameObject.SetActive(true);
            this.UICanvas.gameObject.SetActive(false);
            this.Invoke("UpdateStatus", 0.1f);
        }

        public void LeaveUpgradeCanvas()
        {
            this.UICanvas.gameObject.SetActive(true);
            this.UpgradeCanvas.gameObject.SetActive(false);
        }

        // ReSharper disable once UnusedMember.Local
        private void UpdateStatus()
        {
            EnhancementData.Instance.UpdateStatuses();
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
    }
}
