using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PointManager : MonoBehaviour
{
  
    public Text ScoreText;
    public GameObject [] pins;
    public GameObject ball;
    
    private int Score = 0;

    private Vector3[] initPinsPos;
    private Vector3 initBallPos;

    // Start is called before the first frame update
    void Start()
    {
        initBallPos = ball.transform.position;
        initPinsPos = new Vector3[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            initPinsPos[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        Score = Score + 1;
        ScoreText.text = Score.ToString() + " PTS";
    }
    

public void ReStart()
    {
        ball.transform.position = initBallPos;
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            pins[i].transform.position = initPinsPos[i];
        }

        Score = 0;
        ScoreText.text = Score.ToString() + " PTS";

    }
}

