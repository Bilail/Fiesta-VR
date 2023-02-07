using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfEnabled : MonoBehaviour
{
    public GameObject gun;

    public void TryToShoot()
    {
        if (gameObject.activeInHierarchy)
            gun.GetComponent<SimpleShoot>().Shoot();
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
