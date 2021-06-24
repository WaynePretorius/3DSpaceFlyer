using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    //variable declared that are gloabally changeable
    int score;

    //references to be stored
    TMP_Text scoreText;

    //called as the first function when the script starts
    private void Awake()
    {
        AwakeFunctions();
    }

    //function that calls all related processes at the start
    void AwakeFunctions()
    {
        scoreText = GetComponent < TMP_Text>();
        scoreText.text = "Shoot an Enemy";
    }

    //public method that is called whenever the score must be updated
    public void ModifyScore(int amountToModify)
    {
        score += amountToModify;
        print(score);
        UpdateScoreToText(score);
    }

    //method that updates the UI so the player can see the score
    void UpdateScoreToText(int scoreToUpdate)
    {
        scoreText.text = scoreToUpdate.ToString();
    }
}
