using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartBtn : MonoBehaviour
{
    public BuzzerManager bm;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            btnClick(null);
        }
    }

    public void btnClick(XRBaseInteractor iter)
    {
        if (bm)
            bm.StartGame();
    }
}
