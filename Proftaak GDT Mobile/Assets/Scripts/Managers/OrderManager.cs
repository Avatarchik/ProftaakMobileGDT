namespace Assets.Scripts
{
    using System.Collections.Generic;
    using UnityEngine;    

    public class OrderManager : MonoBehaviour
    {
        public bool test = false;
        [SerializeField]
        private List<IOrderable> Items = new List<IOrderable>();
        public List<string> test2 = new List<string>(); 

        private void Awake()
        {
            foreach (IOrderable io in this.Items)
                io.Setup();
        }
    }
}
