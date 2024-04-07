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

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SwitchToReloadScene();
        }
    }
}