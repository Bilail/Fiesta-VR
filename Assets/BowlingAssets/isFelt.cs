using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFelt : MonoBehaviour
{
    private float rotateX;
    private float rotateZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rotateX = gameObject.transform.rotation.x;
        rotateZ = gameObject.transform.rotation.z;
        if (rotateX >= -0.060 || rotateX >= 0.060 || rotateZ >= -0.060 || rotateZ >= 0.060)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
        }
    }
}
