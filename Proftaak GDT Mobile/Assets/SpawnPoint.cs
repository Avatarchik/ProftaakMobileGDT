using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {


    public bool taken;
    public Vector2 location { get { return transform.position; } private set { location = value; } }

    // Use this for initialization
    void Start () {
	
	}
}
