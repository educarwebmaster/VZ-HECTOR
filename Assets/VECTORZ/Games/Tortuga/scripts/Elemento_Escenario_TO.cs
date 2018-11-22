using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemento_Escenario_TO : MonoBehaviour {
    public float Movimiento, pos;
    public GameObject Respawn;
    private float timeini;
    public GameObject Controlador;

    void Start()
    {
        Controlador = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Controlador.GetComponent<Controler_Game_TO>().estado_game)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - Movimiento, transform.localPosition.y, transform.localPosition.z);
            if (Mathf.Abs(this.transform.localPosition.x) > Mathf.Abs(pos))
            {
                regresar();
            }
        }
    }

    void regresar()
    {
        transform.localPosition = Respawn.transform.localPosition;
    }
}
