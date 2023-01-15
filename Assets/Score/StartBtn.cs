using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public BuzzerManager bm;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bm)
                bm.StartGame();
        }
    }
}
