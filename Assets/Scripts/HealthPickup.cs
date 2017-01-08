using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    public int HealthValue;
    private bool hasBeenTriggered = false;

    public GameObject HealthUIObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameO = other.gameObject;

        if ((gameO.CompareTag("Player") || gameO.CompareTag("PlayerInvincible")) && !hasBeenTriggered)

        {
            // sound
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);

            // Hide sprite
            GetComponent<SpriteRenderer>().enabled = false;

            // update player object
            gameO.SendMessage("GainHealth", HealthValue);

            // solve double trigger
            hasBeenTriggered = true;
            // remove this object
            StartCoroutine(Remove(1));

        }
    }

    IEnumerator Remove(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
