using UnityEngine;
using System.Collections;

public static class MasterGameScore
{
    public static int Score;

    public static int GetScore()
    {
        return Score;
    }

    public static void SetScore(int value)
    {
        Score += value;
    }

    public static void Debuging()
    {
        Debug.Log(Score.ToString());
    }
}
