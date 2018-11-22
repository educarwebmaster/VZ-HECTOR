using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMU_Obstaculo : MonoBehaviour {
    public float Movimiento;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Movimiento, transform.localPosition.y, transform.localPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(this.gameObject);
        }
    }
}
