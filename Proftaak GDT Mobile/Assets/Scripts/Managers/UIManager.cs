namespace Assets.Scripts.Managers
{
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
        }

        public void LeaveUpgradeCanvas()
        {
            this.UICanvas.gameObject.SetActive(true);
            this.UpgradeCanvas.gameObject.SetActive(false);
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
    }
}
