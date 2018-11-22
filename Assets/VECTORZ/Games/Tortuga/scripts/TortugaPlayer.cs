using System.Collections;
using UnityEngine;

public class TortugaPlayer : MonoBehaviour {
    public float Velocidad;
    public bool Der, Izq, sumergir;
    public GameObject Boton, Obstaculo, Particula;
    public Animator anim;
    public AudioSource audio;
    public AudioClip HitAudio, ShowAudio, UnderWaterAudio;
    public Controler_Game_TO controler;
 
    void Update()
    {
        if (Der)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Velocidad);
            Izq = false;
        }
        if (Izq)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Velocidad);
            Der = false;
        }
    }

    public void Derecha_pren()
    {
        Der = true;
    }

    public void Izquierda_pren()
    {
        Izq = true;
    }

    public void Derecha_apa()
    {
        Der = false;
    }

    public void Izquierda_apa()
    {
        Izq = false;
    }

    public void Sumergirse()
    {
        if (!sumergir)
        {
            sumergir = true;
            GetComponent<BoxCollider>().isTrigger = true;
            anim.SetInteger("miani", 2);
            anim.Play("Sumergirse");
            audio.PlayOneShot(UnderWaterAudio);
            StartCoroutine(Activar());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            collision.gameObject.GetComponent<Elemento_Obstaculo_TO>().enabled = false;
            audio.PlayOneShot(HitAudio);
            
            this.GetComponent<Rigidbody>().isKinematic = true;
            Der = false;
            Izq = false;
            anim.SetInteger("miani", 1);
            anim.Play("Morir");
            StartCoroutine("Final");
            Boton.SetActive(false);
            Obstaculo.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Aumentar")
        {
            controler.Puntuar();
            Destroy(other.gameObject);
        }*/

        if (other.gameObject.tag == "Item")
        {
            if (!sumergir)
            {
                controler.Puntuar();
                Destroy(other.gameObject);
                Particula.GetComponent<Animator>().Play("Particula");
            }
        }
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        controler.MostarRetro();
        audio.PlayOneShot(ShowAudio);
    }

    public IEnumerator Activar()
    {
        yield return new WaitForSeconds(5);
        sumergir = false;
        GetComponent<BoxCollider>().isTrigger = false;
        anim.SetInteger("miani", 0);
        anim.Play("Nadar");
    }
}
