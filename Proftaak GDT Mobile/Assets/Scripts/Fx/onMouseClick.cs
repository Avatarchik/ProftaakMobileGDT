using UnityEngine;
using System.Collections;

public class onMouseClick : MonoBehaviour {

    [SerializeField]
    private GameObject bubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //debugging
            Vector3 pusherPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 1));

            Instantiate(bubble, pusherPos, Quaternion.identity);
        }
    }

}

