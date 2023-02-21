
using System.Collections;  

using System.Collections.Generic;  
using UnityEngine;    
public class BowlingBall : MonoBehaviour
{
    public float force = 2000;
    private List<Vector3> pinPositions;     
    private List<Quaternion> pinRotations;      
    private Vector3 ballPosition;
    public Transform throwPosition;
    void Start()      {          
          
    }          
    void Update()      
    {          
                
        
    }     
    public void ThrowBall()      
    {
        //float yRotation = Input.GetAxis("ControllerYRotation");
        //GetComponent<Rigidbody>().transform.rotation = Quaternion.Euler(new Vector3(0, yRotation, 0));
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -force));
        GetComponent<Rigidbody>().AddForce(throwPosition.forward*force, ForceMode.Impulse);

        Debug.Log("Laché");
    }
}



