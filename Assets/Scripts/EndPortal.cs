using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour
{
    public string nextScene;
    public GameScore GS;
    public void LoadScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || 
            other.gameObject.tag == "PlayerInvincible")
        {
            // Pass Score to next level
            MasterGameScore.SetScore(GS.Score);
            MasterGameScore.Debuging();
            LoadScene(nextScene);
        }
    }



}

