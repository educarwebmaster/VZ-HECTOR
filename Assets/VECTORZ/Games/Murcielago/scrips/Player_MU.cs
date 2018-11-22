using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_MU : MonoBehaviour {
    public Transform posicionInicial;
    public float volar;
    public Animator anim;
    public GameObject Boton, Reinicia,Obstaculo;
    public Controler_Game_MU controler;
    public AudioSource audio;
    public AudioClip VolarAudio,HitAudio,ShowAudio;
    public AudioMixer hit,Show;

    void Start()
    {
        posicionInicial = this.transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            GetComponent<Rigidbody>().mass = 1.0f;
            GetComponent<Rigidbody>().drag = 1.0f;
            GetComponent<CapsuleCollider>().enabled = false;
            audio.PlayOneShot(HitAudio);
            audio.outputAudioMixerGroup = hit.outputAudioMixerGroup;
            anim.Play("Caer");
            StartCoroutine("Final");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Aumentar")
        {
            controler.Puntuar();
            Destroy(other.gameObject);
        }
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        Boton.SetActive(false);
        controler.MostarRetro();
        audio.PlayOneShot(ShowAudio);
        
        audio.outputAudioMixerGroup = Show.outputAudioMixerGroup;
        Obstaculo.SetActive(false);
    }

    public void Volar()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.up * volar);
        anim.Play("Volar");
        audio.PlayOneShot(VolarAudio);
    }

    public void Reiniciar()
    {
        this.transform.localPosition = posicionInicial.localPosition;
    }
}
