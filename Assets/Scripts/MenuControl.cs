using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        Screen.SetResolution(1024, 600, true);
        MasterGameScore.Score = 0;
        SceneManager.LoadScene(sceneName);

    }

    public void Quit()
    {
        
        Application.Quit();
    }

}
