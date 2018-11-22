using UnityEngine;
using System.Collections;

public class AnimacionTouch : MonoBehaviour
{
    public Animator Anim;
    public bool Audio;
    public AudioSource ControlerAudio;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Anim.Play("Iniciar");
            if (Audio)
            {
                ControlerAudio.Play();
            }
        }
    }

    void OnMouseDown()
    {
        Anim.Play("Iniciar");
        if (Audio)
        {
            ControlerAudio.Play();
        }
    }
}
