using UnityEngine.SceneManagement;

public interface ISingleton
{
    void Init();
    void Init(Scene scene, LoadSceneMode mode);
    void SetDefaults();
}
