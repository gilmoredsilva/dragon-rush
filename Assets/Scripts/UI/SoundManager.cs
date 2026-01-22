using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip mainTheme; // assign this in Inspector to your main theme clip

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            // Play the main theme at game start
            PlayMainTheme();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void PlayMainTheme()
    {
        if (audioSource.clip == null || audioSource.clip.name != mainTheme.name)
        {
            audioSource.clip = mainTheme;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        audioSource.PlayOneShot(_sound);
    }

    public void StopSound(AudioClip _sound)
    {
        audioSource.Stop();
    }

    public void PlayLoopMusic(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public bool IsPlaying(string soundName)
    {
        return audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name == soundName;
    }

    public void RestartMainTheme(AudioClip clip)
{
    if (clip == mainTheme)
    {
        audioSource.clip = mainTheme;
        audioSource.loop = true;
        audioSource.Play();
    }
}

    public void StopAll()
    {
        AudioSource[] allSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource source in allSources)
        {
            source.Stop();
        }
    }
}
