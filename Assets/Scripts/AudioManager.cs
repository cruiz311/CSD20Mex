using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public string channelVolume;
    public float currentVolume = 0.5f;
    public AudioMixer myMixer;
    public float valueVolume;
    public Sprite[] buttonMute;
    public bool isMuted;
    public AudioClip backgroundMusic; // The background music clip
    private AudioSource audioSource; // The audio source for playing background music

    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        UpdateAudioVolume();
        audioSource.Play(); // Start playing background music
    }

    void UpdateAudioVolume()
    {
        if (isMuted)
        {
            myMixer.SetFloat(channelVolume, -80);
        }
        else
        {
            myMixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
        }

        audioSource.volume = currentVolume; // Update the volume of the audio source
    }

    public void ToggleMute(Button button)
    {
        isMuted = !isMuted;
        UpdateAudioVolume();
        button.image.sprite = isMuted ? buttonMute[0] : buttonMute[1];
    }

}
