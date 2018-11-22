using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMU_Escenario : MonoBehaviour {

    public float Movimiento, time, time_reduccion;
    public GameObject Respawn;
    private float timeini;

    void Start()
    {
        timeini = time;
    }

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Movimiento, transform.localPosition.y, transform.localPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            regresar();
        }
    }




    void regresar()
    {
        time = timeini;
        transform.localPosition = Respawn.transform.localPosition;
    }
}
