using UnityEngine;

namespace Assets.Scripts.Enhancements
{
    public class Marketing : MonoBehaviour, IUpgrade
    {
        string IUpgrade.Name { get; set; }

        uint IUpgrade.RequiredPoints { get; set; }

        public bool Upgrade()
        {
            Debug.Log("Upgrade values...");
            return true;

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
