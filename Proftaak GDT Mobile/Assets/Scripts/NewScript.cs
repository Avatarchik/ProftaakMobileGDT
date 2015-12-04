using UnityEngine;

namespace Assets.Scripts
{
    public class NewScript : MonoBehaviour
    {

        [SerializeField]
        private bool _isVisualStudioCool;

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            this._isVisualStudioCool = true;
        }
    }
}
