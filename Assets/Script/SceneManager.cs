using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Object currentScene;
    [SerializeField] private Object nextScene;

    private void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SwitchScene(currentScene.name);
        }
    }
}