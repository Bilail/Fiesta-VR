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
        //ball.transform.position = new Vector3(1.409f, -0.953f, -5.114f);
        ball.transform.position = initBallPos;
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            pins[i].transform.position = initPinsPos[i];
        }

        /*
        pins[0].transform.position = new Vector3(-0.51f, 0.2f, 0f);
        pins[1].transform.position = new Vector3(-1.073f, 0.2f, 0.6919f);
        pins[2].transform.position = new Vector3(-1.071f, 0.2f, -0.004f);
        pins[3].transform.position = new Vector3(-1.617f, 0.2f, -0.003f);
        pins[4].transform.position = new Vector3(-0.2280f, 0.2f, 0.375f);
        pins[5].transform.position = new Vector3(-0.763f, 0.2f, -2.863f);
        pins[6].transform.position = new Vector3(-1.361f, 0.2f, 0.3699f);
        pins[7].transform.position = new Vector3(-0.5270f, 0.2f, 0.7009f);
        pins[8].transform.position = new Vector3(-0.7670f, 0.2f, 0.3919f);
        pins[9].transform.position = new Vector3(0f, 0.2f, 0f);*/
        Score = 0;
        ScoreText.text = Score.ToString() + " PTS";

    }
}

