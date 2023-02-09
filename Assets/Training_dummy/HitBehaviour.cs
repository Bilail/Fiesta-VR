using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequiereComponent(typeof(Collider))]

public class HitBehaviour : MonoBehaviour
{
    public AudioSource sound;

    public Animator animator;

    public GameManager gameManager;

    public int score;
    
    public GameObject prefabExplosion;

    void OnCollisionEnter(Collision collision)
    {
        gameManager.UpdateScore(score);
        //sound.Play();
        animator.SetTrigger("Hit");
        
        GameObject explosion = Instantiate(prefabExplosion, transform.position, transform.rotation);
        explosion.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        Destroy(collision.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
