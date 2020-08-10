using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Points : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public static Points instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }


}
