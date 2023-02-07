using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public AudioSource sound;
    //public Console console;
    
    public int impulseFactor = 10;
    public float ballLifeTime = 4f;

    private List<float> creationStamp;
    private List<GameObject> ballsGameObjects;

    private bool lastTriggerValue = false;
    public float inbetweenShootsTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        creationStamp = new List<float>();
        ballsGameObjects = new List<GameObject>();
        
        //console.AddLine("Let's Go");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < creationStamp.Count; i++)
        {
            if(Time.time - creationStamp[i] > ballLifeTime)
            {
                Destroy(ballsGameObjects[i]);
                
            }
        }
    }

    public void Shoot()
    {
        Rigidbody ball = CreateBall();
        Launch(ball);
        sound.Play();
    }
    
    public void Launch(Rigidbody ball)
    {
        ball.AddForce(transform.forward * impulseFactor, ForceMode.Impulse);
    }
    
    public Rigidbody CreateBall()
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = transform.position;
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
        Rigidbody ballRigidbody = ball.AddComponent<Rigidbody>();
        
        ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        creationStamp.Add(Time.time);
        ballsGameObjects.Add(ball);
        return ballRigidbody;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(isActiveAndEnabled && !lastTriggerValue /**&& trigerValue**/)
        {
            Shoot();
            //lastTriggerValue = trigerValue;
        }
    }
}
