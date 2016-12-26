using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

    Text scoreTextUI;
    int score;

    public int Score { get; set; }

    // Use this for initialization
    void Start ()
    {
        // Get the text from this game component
        scoreTextUI = GetComponent<Text>();
        // Pull score from the Master Score (cross-level)
        score = MasterGameScore.Score;
        MasterGameScore.Debuging();

	}
	
	// Update is called once per frame
	void Update ()
    {
        string output = "Score  ";
        string output2 = score.ToString();

        scoreTextUI.text = output + output2;
	}

    public void IncrementScore (int points)
    {
        score += points;
    }
}
