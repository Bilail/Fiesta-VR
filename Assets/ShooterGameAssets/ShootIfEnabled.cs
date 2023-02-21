using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfEnabled : MonoBehaviour
{
    public GameObject gun;
    public AudioSource shootSound;
    private float lastShoot = 0;
    public void TryToShoot()
    {
        if (gameObject.activeInHierarchy && Time.time - lastShoot > 0.7f)
        {
            lastShoot = Time.time;
            gun.GetComponent<SimpleShoot>().ShootBullet();
            shootSound.Play();
        }
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
