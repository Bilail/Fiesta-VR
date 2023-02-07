using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFelt : MonoBehaviour
{
    private float rotateX;
    private float rotateZ;
    public AudioClip clip;
    public AudioSource audioSource;
    public PointManager mg;
    private bool tombe = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(gameObject.transform.position);
        rotateX = gameObject.transform.rotation.x;
        rotateZ = gameObject.transform.rotation.z;
        if (rotateX >= -0.060 || rotateX >= 0.060 || rotateZ >= -0.060 || rotateZ >= 0.060)
        {

            if (tombe == false)
            {

                //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                tombe = true;
                mg.UpdateScore();
                //mg.ReStart();
                audioSource.Play();
            }
        }
    }
}
