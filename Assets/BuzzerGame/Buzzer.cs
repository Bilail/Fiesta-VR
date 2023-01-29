using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Buzzer : MonoBehaviour
{
    private BuzzerManager bm;
    private int id;

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
