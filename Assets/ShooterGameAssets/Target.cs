using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

	

    public bool isTargetPractice = false;
    public float health = 10f;
    public float defaultHealth = 100f;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        defaultHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        if(isTargetPractice)
        {
            health = defaultHealth;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("Target is dead");
    }
}