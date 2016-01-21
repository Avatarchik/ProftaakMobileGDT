using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{

    public Text text;

	// Use this for initialization
	void Start ()
	{

	    float totalTime = PlayerPrefs.GetFloat("TotalTime");
	    float minutes = Mathf.Floor(totalTime/60);
	    float seconds = totalTime - (minutes * 60);
	    this.text.text = "Je hebt er " + minutes + " minutes en " + seconds + " seconden over gedaan.";
        Debug.Log(totalTime + " " + minutes + " " + seconds );

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
