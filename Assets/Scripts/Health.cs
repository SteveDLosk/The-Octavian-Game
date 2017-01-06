using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    Text healthTextUI;
    int health;

    public int HP { get; set; }

    // Use this for initialization
    void Start()
    {
        // Get the text from this game component
        healthTextUI = GetComponent<Text>();
        HP = 30;

    }

    // Update is called once per frame
    void Update()
    {
        string output = "Health  ";
        string output2 = HP.ToString();

        healthTextUI.text = output + output2;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Take damage");
    }

    public void GainHealth(int health)
    {
        HP += health;
        Debug.Log("Gain health");
    }
}