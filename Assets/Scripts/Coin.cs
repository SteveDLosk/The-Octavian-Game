using UnityEngine;
using System.Collections;
using System.Text;

public class Coin : MonoBehaviour
{
    public int CoinValue;
    public string TreasureName;
    
    //public GameScore ScoreController;
    public GameObject ScoreUIObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameO = other.gameObject;

        if (gameO.CompareTag("Player") || gameO.CompareTag("PlayerInvincible"))
        
        {
            // sound
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);

            gameO.SendMessage("GainTreasure", CoinValue);
            // Hide object from screen
            GetComponent<SpriteRenderer>().enabled = false;
            // send score message to UI
            ScoreUIObject.SendMessage("IncrementScore", (CoinValue));

            // Update Master Score
            MasterGameScore.SetScore(CoinValue);
            //MasterGameScore.Debuging();

            // remove coin
            StartCoroutine(Remove(1));

        }
    }

    IEnumerator Remove(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}