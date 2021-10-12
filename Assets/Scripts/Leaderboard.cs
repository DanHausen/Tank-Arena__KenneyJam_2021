using System;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    protected static Text _scorePointsText;
    private int _points;

    void Start(){
        _scorePointsText = GameObject.Find("ScorePointsText").GetComponent<Text>();
    }

    public static void LeaderboardUpdater(int _score){
        int _points = Int32.Parse(_scorePointsText.text);
        _points += _score;
        _scorePointsText.text = "00000000" + _points.ToString();
    }
}
