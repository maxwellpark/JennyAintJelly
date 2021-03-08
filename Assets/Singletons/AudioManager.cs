using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource MusicAudio;
    public AudioSource ProjectileAudio;

    [SerializeField] AudioClip route1Track;
    [SerializeField] AudioClip cavesTrack;
    [SerializeField] AudioClip militaryBaseTrack;

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
                MusicAudio.clip = route1Track;
                break;
            case Level.Caves:
                MusicAudio.clip = cavesTrack;
                break;
            case Level.MilitaryBase:
                MusicAudio.clip = militaryBaseTrack;
                break;
        }
        MusicAudio.Play();
        MusicAudio.loop = true;
    }
}
