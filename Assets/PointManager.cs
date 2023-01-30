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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        Score = Score + 1;
        ScoreText.text = Score.ToString();
    }

    public void ReStart()
    {
        ball.transform.position = new Vector3(1,2,-2);
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
        }
        pins[0].transform.position = new Vector3(1,1.684f,-13.86f);
        pins[1].transform.position = new Vector3(0.09f, 1.732f, -13.86f);
        pins[2].transform.position = new Vector3(1.26f, 1.678f, -13.52f);
        pins[3].transform.position = new Vector3(0.563f, 1.747f, -13.83f);
        pins[4].transform.position = new Vector3(0.79f, 1.739f, -13.5f);
        pins[5].transform.position = new Vector3(0.34f, 1.73f, -13.48f);
        pins[6].transform.position = new Vector3(1.03f, 1.733f, -13.07f);
        pins[7].transform.position = new Vector3(1.45f, 1.669f, -13.93f);
        pins[8].transform.position = new Vector3(0.82f, 1.733f, -12.61f);
        pins[9].transform.position = new Vector3(0.59f, 1.7337f, -13.06f);

        
    }
}

