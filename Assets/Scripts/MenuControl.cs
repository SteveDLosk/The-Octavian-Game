using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        MasterGameScore.Score = 0;
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

}
