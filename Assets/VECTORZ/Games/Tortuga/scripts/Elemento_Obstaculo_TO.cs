using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemento_Obstaculo_TO : MonoBehaviour {

    public float Movimiento;
    public GameObject Controlador;

    void Start()
    {
        Controlador = GameObject.FindGameObjectWithTag("MainCamera");
        Destroy(this.gameObject,40f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Controlador.GetComponent<Controler_Game_TO>().estado_game)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - Movimiento, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
