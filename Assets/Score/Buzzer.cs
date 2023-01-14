using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzer : MonoBehaviour
{
    private BuzzerManager bm;
    private int id;

    public void init(BuzzerManager bm, int id)
    {
        this.bm = bm;
        this.id = id;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bm)
                bm.buttonClicked(id);
        }
    }
}
