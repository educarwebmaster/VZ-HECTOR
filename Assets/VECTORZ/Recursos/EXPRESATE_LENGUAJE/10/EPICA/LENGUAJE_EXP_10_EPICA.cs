using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LENGUAJE_EXP_10_EPICA : MonoBehaviour {

    public GameObject[] Obj;
    public float[] Obj_Time;
    public int Slider;
    public float Tiempo, Temp;


    void Update()
    {
        if (Tiempo > 0.0f)
        {
            Tiempo -= Obj_Time[Slider];
        }
        else
        {
            Siguiente();
            Tiempo = Temp;
        }
    }



    public void Siguiente()
    {
        if (Slider < Obj.Length)
        {
            Desaparecer();
            Slider++;
            Obj[Slider].SetActive(true);
        }
        else
        {
            Desaparecer();
            Slider = 0;
            Obj[Slider].SetActive(true);
        }
    }

    public void Desaparecer()
    {
        for (int i = 0; i < Obj.Length; i++)
        {
            Obj[i].SetActive(false);
        }
    }
}
