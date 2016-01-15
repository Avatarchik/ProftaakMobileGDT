namespace Assets.Scripts
{
    using UnityEngine;

    [SerializeField]
    public interface IOrderable
    {
        // Added for serialization, but doesn't seem to work :(
        bool Orderable { get; set; }
        void Setup();
    }
}
