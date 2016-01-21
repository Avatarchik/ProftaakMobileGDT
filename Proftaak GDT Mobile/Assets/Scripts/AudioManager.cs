using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {


    public AudioSource FeedbackAudioSource;
    public AudioSource NotificationAudioSource;

    public AudioClip ButtonClickSound;
    public AudioClip FeedbackPositiveSound;
    public AudioClip FeedbackNegativeSound;
    public AudioClip NotificationSound;

    public AudioClip ButtonSpawnSound;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayPositiveFeedback()
    {
        FeedbackAudioSource.PlayOneShot(FeedbackPositiveSound);
    }

    public void PlayNegativeFeedback()
    {
        FeedbackAudioSource.PlayOneShot(FeedbackNegativeSound);
    }

    public void PlayNotification()
    {
        NotificationAudioSource.PlayOneShot(NotificationSound);
    }

    public void PlayButtonClick(AudioClip c)
    {
        NotificationAudioSource.PlayOneShot(c);
    }

    public void PlaySpawnObject(){

        NotificationAudioSource.PlayOneShot(ButtonSpawnSound);
    }

}
