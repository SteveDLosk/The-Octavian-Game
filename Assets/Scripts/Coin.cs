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
            // remove coin
            Destroy(gameObject);

            gameO.SendMessage("GainTreasure", CoinValue);

            // send score message to UI
            ScoreUIObject.SendMessage("IncrementScore", (CoinValue));

            // Update Master Score
            MasterGameScore.SetScore(CoinValue);
            //MasterGameScore.Debuging();
        }
    }
}