using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour
{
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }

    public void loadSceneSingle(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);

    }

    public void unloadSceneCamera()
    {
        SceneManager.UnloadSceneAsync("menu");
        SceneManager.UnloadSceneAsync("new");
        SceneManager.UnloadSceneAsync("share");
        SceneManager.UnloadSceneAsync("placement");
    }
}