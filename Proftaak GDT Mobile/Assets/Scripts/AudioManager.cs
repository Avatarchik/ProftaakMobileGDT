using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource FeedbackAudioSource;
    public AudioSource NotificationAudioSource;

    public AudioClip ButtonClickSound;
    public AudioClip FeedbackPositiveSound;
    public AudioClip FeedbackNegativeSound;
    public AudioClip NotificationSound;

    public AudioClip ButtonSpawnSound;

    [SerializeField]
    private AudioClip _upgradeAvailableSound;
    [SerializeField]
    private AudioClip _upgradeDoneSound;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayPositiveFeedback()
    {
        this.FeedbackAudioSource.PlayOneShot(this.FeedbackPositiveSound);
    }

    public void PlayNegativeFeedback()
    {
        this.FeedbackAudioSource.PlayOneShot(this.FeedbackNegativeSound);
    }

    public void PlayNotification()
    {
        this.NotificationAudioSource.PlayOneShot(this.NotificationSound);
    }

    public void PlayButtonClick(AudioClip c)
    {
        this.NotificationAudioSource.PlayOneShot(c);
    }

    public void PlaySpawnObject()
    {
        this.NotificationAudioSource.PlayOneShot(this.ButtonSpawnSound);
    }
    public void PlayUpgradesAvailable()
    {
        this.NotificationAudioSource.PlayOneShot(this._upgradeAvailableSound);
    }
    public void PlayUpgradeDone()
    {
        this.NotificationAudioSource.PlayOneShot(this._upgradeDoneSound);
    }
}
