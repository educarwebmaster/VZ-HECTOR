using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour {
    public string[] Animaciones;
    public Image[] Botones;
    public AudioClip[] Audios;
    public Color Transparente, Blanco;
    public GameObject Camera,Animal;
    public string Animacion;
    public AudioSource Audio;

    public void Pasar(int pos)
    {
        for (int i = 0;i<Botones.Length;i++)
        {
            Botones[i].color = Transparente;
            Botones[i].transform.GetChild(0).gameObject.GetComponent<Text>().color = Transparente;
        }
        Botones[pos].color = Blanco;
        Botones[pos].transform.GetChild(0).gameObject.GetComponent<Text>().color = Blanco;
        Camera.GetComponent<Animator>().Rebind();
        Camera.GetComponent<Animator>().Play(Animaciones[pos]);
        Animal.GetComponent<Animator>().Rebind();
        Animal.GetComponent<Animator>().Play(Animaciones[pos]);
        Animacion = Animaciones[pos];
        Audio.Stop();
        Audio.PlayOneShot(Audios[pos]);
    }

    public void Regresar()
    {
        Camera.GetComponent<Animator>().Rebind();
        Camera.GetComponent<Animator>().Play(Animacion, 1);
        Animal.GetComponent<Animator>().Rebind();
        Animal.GetComponent<Animator>().Play(Animacion, 1);
    }

    public void Volver(string scena)
    {
        PlayerPrefs.SetString("ScenaActual", scena);
        SceneManager.LoadScene("Transcicion");
    }
}
