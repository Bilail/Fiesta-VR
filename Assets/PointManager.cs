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
        ball.transform.position = new Vector3(1.409f, -0.953f, -5.114f);
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
        }
        pins[0].transform.position = new Vector3(1.798f, -0.855f, -7.529f);
        pins[1].transform.position = new Vector3(1.235f, -0.855f, -6.837f);
        pins[2].transform.position = new Vector3(1.237f, -0.855f, -7.533f);
        pins[3].transform.position = new Vector3(0.691f, -0.855f, -7.532f);
        pins[4].transform.position = new Vector3(2.08f, -0.855f, -7.154f);
        pins[5].transform.position = new Vector3(1.541f, -0.855f, -6.47f);
        pins[6].transform.position = new Vector3(0.947f, -0.855f, -7.159f);
        pins[7].transform.position = new Vector3(1.781f, -0.855f, -6.828f);
        pins[8].transform.position = new Vector3(1.541f, -0.855f, -7.137f);
        pins[9].transform.position = new Vector3(2.308f, -0.855f, -7.529f);
        Score = 0;
        ScoreText.text = Score.ToString();

    }
}

