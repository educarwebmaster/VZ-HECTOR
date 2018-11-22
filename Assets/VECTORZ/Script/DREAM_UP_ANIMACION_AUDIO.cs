using UnityEngine;
using System.Collections;

[System.Serializable]
public class Elemento_Animacion_audio
{
    public AudioClip audio;
    public Animator anim;
    public string animacion;
    public bool animar;
}

public class DREAM_UP_ANIMACION_AUDIO : MonoBehaviour {
    public Elemento_Animacion_audio[] Objeto;
    private AudioSource Audio;

	void Start () {
	
	}

	void Update () {
	
	}

    public void Animacion(int Elemento)
    {
        if (Objeto[Elemento].animar)
        {
            Audio.clip = Objeto[Elemento].audio;
            Audio.Play();
            Objeto[Elemento].anim.Play(Objeto[Elemento].animacion);
        }
        else
        {
            Audio.clip = Objeto[Elemento].audio;
            Audio.Play();
        }
        
    }
}
