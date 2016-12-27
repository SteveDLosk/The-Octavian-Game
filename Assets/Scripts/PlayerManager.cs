using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{


    public GameObject HealthUI;
    public int score { get; set; }
    public int health { get; set; }

    void Start()
    {
        health = 30;
    }
    // Player damage
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if hits an enemy, and if player is a currently valid target
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player")
        {
            TakeDamage(5);        
        }

    }

    IEnumerator Invincible(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.tag = "Player";
    }

    void GainHealth (int value)
    {
        health += value;
        HealthUI.SendMessage("GainHealth", value);
    }

    void TakeDamage (int damage)
    {
        health -= damage;
        HealthUI.SendMessage("TakeDamage", damage);

        // make player temporarily unAttackable
        gameObject.tag = "PlayerInvincible";
        StartCoroutine(Invincible(3));
       
        // Check for game over
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void GainTreasure (int value)
    {
        score += value;
    }

    void FellToDeath ()
    {
        Scene s = SceneManager.GetActiveScene();
        string str = (s.name);

        if (str == "BonusLevel")
            SceneManager.LoadScene("WinEnd");
        else
            SceneManager.LoadScene("GameOver");
    }
}
