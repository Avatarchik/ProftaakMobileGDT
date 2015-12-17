namespace Assets.Scripts.RandomEvents
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class Balloon : MonoBehaviour
    {
        public static float MinTimeToDestroy = 3f;
        public static float MaxTimeToDestroy = 6f;


        private bool _LOG = true;

        [SerializeField]
        private Image _image;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            this.Invoke("Destroy", Random.Range(MinTimeToDestroy, MaxTimeToDestroy));
        }

        // ReSharper disable once UnusedMember.Local
        private void Destroy()
        {
            if (this._LOG)
                Debug.Log("Destroying wolkje");
            GameObject.Destroy(this);
        }

        public void OnClick()
        {

        }

    }
}
