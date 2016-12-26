using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour
{
    public PlayerManager pm;
    private int score;
    private int health;
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        score = pm.score;
        health = pm.health;

	}
}
