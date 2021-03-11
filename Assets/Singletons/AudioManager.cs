using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource MusicAudio;
    public AudioSource ProjectileAudio;
    public AudioSource ProjectileReloadAudio;

    [SerializeField] AudioClip route1Clip;
    [SerializeField] AudioClip cavesClip;
    [SerializeField] AudioClip militaryBaseClip;
    [SerializeField] AudioClip reloadClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        GameManager.OnLevelTransition += ChangeTrack;
    }

    private void ChangeTrack()
    {
        switch (GameManager.CurrentLevel)
        {
            case Level.Route1:
                MusicAudio.clip = route1Clip;
                break;
            case Level.Caves:
                MusicAudio.clip = cavesClip;
                break;
            case Level.MilitaryBase:
                MusicAudio.clip = militaryBaseClip;
                break;
        }
        MusicAudio.Play();
        MusicAudio.loop = true;
    }
}
