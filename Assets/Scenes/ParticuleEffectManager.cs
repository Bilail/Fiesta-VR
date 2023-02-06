using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleEffectManager : MonoBehaviour
{
    public GameObject particuleEmitterPrefab;

    private GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = Instantiate(particuleEmitterPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(instance);
    }
}
