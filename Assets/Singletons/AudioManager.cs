using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    // Sources
    public AudioSource MusicAudio;
    public AudioSource ProjectileAudio;
    public AudioSource ProjectileReloadAudio;

    // Clips
    [SerializeField] private AudioClip route1Clip;
    [SerializeField] private AudioClip cavesClip;
    [SerializeField] private AudioClip cavesBossClip;
    [SerializeField] private AudioClip militaryBaseClip;
    [SerializeField] private AudioClip reloadClip;

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
        SceneManager.sceneLoaded += ChangeTrack;
    }

    private void ChangeTrack(Scene scene, LoadSceneMode mode)
    {
        if (MusicAudio != null)
        {
            switch (GameManager.CurrentLevel)
            {
                case Level.Route1:
                    MusicAudio.clip = route1Clip;
                    break;
                case Level.Caves:
                    MusicAudio.clip = cavesClip;
                    break;
                case Level.CavesBoss:
                    MusicAudio.clip = cavesBossClip;
                    break;
                case Level.MilitaryBase:
                    MusicAudio.clip = militaryBaseClip;
                    break;
            }
        }
        MusicAudio.Play();
        MusicAudio.loop = true;
    }
}
