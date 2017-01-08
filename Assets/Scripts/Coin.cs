using UnityEngine;
using System.Collections;
using System.Text;

public class Coin : MonoBehaviour
{
    public int CoinValue;
    public string TreasureName;
    
    //public GameScore ScoreController;
    public GameObject ScoreUIObject;
    private bool hasBeenTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameO = other.gameObject;

        if ((gameO.CompareTag("Player") || gameO.CompareTag("PlayerInvincible")) && !hasBeenTriggered)
        
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

            // solve double-triggering
            hasBeenTriggered = true;

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