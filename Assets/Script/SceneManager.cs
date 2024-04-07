using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Object currentScene;
    [SerializeField] private Object nextScene;

    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(nextScene.name);
    }
    public void SwitchToReloadScene()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SwitchToNextScene();
        }
    }
}