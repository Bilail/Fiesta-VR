using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Buzzer : MonoBehaviour
{
    private BuzzerManager bm;
    private int id;

    void Start()
    {
        gameObject.GetComponent<Light>().enabled = false;
        gameObject.GetComponent<Light>().color = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    public void Init(BuzzerManager bm, int id)
    {
        this.bm = bm;
        this.id = id;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BuzzerClick(null);
        }
    }
    public void BuzzerClick(XRBaseInteractor iter)
    {
        if (bm)
            bm.BuzzerClick(id);
    }
}
