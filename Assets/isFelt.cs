using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class isFelt : MonoBehaviour
{
    public PointManager mg;
    private float rotateX;
    private float rotateZ;
    private bool tombe = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.position);
        rotateX = gameObject.transform.rotation.x;
        rotateZ = gameObject.transform.rotation.z;
        if (rotateX >= -0.060 || rotateX >= 0.060 || rotateZ >= -0.060 || rotateZ >= 0.060)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
            if (tombe == false)
            {
                
                //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                tombe = true;
                mg.UpdateScore();
                //mg.ReStart();
            }
        }
    }
}
