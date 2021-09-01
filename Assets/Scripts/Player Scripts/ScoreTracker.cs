using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public float score;
    public float temp; //MINE
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "SCORE: " + score.ToString("0000");
    }

    //void Uodate ()
    //{
    //    AddScore(score);
    //}

    public void AddScore(float value)
    {
        score += value;
        temp = score;
        scoreText.text = "SCORE: " + score.ToString("0000");
        Debug.Log("SCORE is " + score);

        if(score >= 300) //victory scene
        {
            temp = score;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            score = temp;
            scoreText.text = "SCORE: " + score.ToString("0000");
            Debug.Log("SCORE is " + score);
        }
    }
}
