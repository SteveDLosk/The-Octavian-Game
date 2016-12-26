using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    public int HealthValue;

    public GameObject HealthUIObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameO = other.gameObject;

        if (gameO.CompareTag("Player") || gameO.CompareTag("PlayerInvincible"))

        {
            // remove this object
            Destroy(gameObject);

            // update player object
            gameO.SendMessage("GainHealth", HealthValue);
            
            
        }
    }
}
