using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controler_Game_MU : MonoBehaviour {
    public int Puntos,Vidas, Inicio;
    public Player_MU Player;
    public GameObject AnimacionPuntaje, Retro, Puntosanim,Tutorial;
    public GameObject[] ObjetoObstaculo,Scenario;
    public Transform[] Spawn;
    public float Tiempo,Disminucion;
    public Text Puntos_t,puntajef,puntajel;
    public bool estado_game;

    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialMU"))
        {
            PlayerPrefs.SetInt("TutorialMU", 0);
            Tutorial.SetActive(true);
            Detener();
        }
        else
        {
            Tutorial.SetActive(false);
            Iniciar();
        }

        if (PlayerPrefs.HasKey("RecordMU"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("RecordMU", 0);
        }
    }

    void Update()
    {
        if (estado_game)
        {
            if (Tiempo > 0)
            {
                Tiempo -= Disminucion;
            }
            else
            {

                Tiempo = 1;
                int r = Random.Range(0, ObjetoObstaculo.Length);
                Instantiate(ObjetoObstaculo[r], Spawn[r]);
            }
            Puntos_t.text = Puntos + "";
        }
    }

    public void Iniciar()
    {
        for (int i = 0; i < Scenario.Length; i++)
        {
            Scenario[i].SetActive(true);
        }
        estado_game = true;
    }

    public void Detener()
    {
        for (int i = 0; i < Scenario.Length; i++)
        {
            Scenario[i].SetActive(false);
        }
        estado_game = false;
    }

    public void MostarRetro()
    {
        Retro.SetActive(true);
        puntajef.text = Puntos + "";
        if (Puntos > PlayerPrefs.GetInt("RecordMU"))
        {
            PlayerPrefs.SetInt("RecordMU", Puntos);
        }
        puntajel.text = PlayerPrefs.GetInt("RecordMU") + "";
    }

    public void Puntuar()
    {
        Puntos++;
        GameObject AnimaPuntaje =  Instantiate(AnimacionPuntaje) as GameObject;
        AnimaPuntaje.transform.SetParent(Puntos_t.transform.parent);
        AnimaPuntaje.SetActive(true);
        AnimaPuntaje.transform.localPosition = Puntos_t.transform.localPosition;
        AnimaPuntaje.transform.localRotation = Puntos_t.transform.localRotation;
        AnimaPuntaje.transform.localScale = Puntos_t.transform.localScale;
        AnimaPuntaje.gameObject.GetComponent<Animator>().Play("Puntaje");
        Puntosanim.GetComponent<Animator>().Play("PuntageAnim");
        Destroy(AnimaPuntaje, 1f);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Game_MU");
    }

    public void Volver(string scena)
    {
        PlayerPrefs.SetString("ScenaActual", scena);
        SceneManager.LoadScene("Transcicion");
    }
}
