using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{

    public Text text;
    
    // ReSharper disable once UnusedMember.Local
    private void Start ()
	{

	    float totalTime = PlayerPrefs.GetFloat("TotalTime");
	    float minutes = Mathf.Floor(totalTime/60);
	    float seconds = totalTime - (minutes * 60);
	    this.text.text = "Je hebt er " + minutes + " minuten en " + seconds + " seconden over gedaan.";
        Debug.Log(totalTime + " " + minutes + " " + seconds );

    }

    public void ButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
