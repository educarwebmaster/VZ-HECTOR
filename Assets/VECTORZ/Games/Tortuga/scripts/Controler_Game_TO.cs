using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controler_Game_TO : MonoBehaviour
{
    public int Puntos, Vidas, Inicio;
    public TortugaPlayer Player;
    public GameObject AnimacionPuntaje, Retro, Puntosanim, Tutorial;
    public GameObject[] ObjetoObstaculo, Scenario,Items;
    public Transform[] Spawn,ItemsSpawn;
    public float Tiempo, Disminucion;
    public Text Puntos_t, puntajef, puntajel;
    public bool estado_game;
    float tinicial = 0.0f;
    void Awake()
    {
        #if UNITY_EDITOR
                QualitySettings.vSyncCount = -1;  // VSync must be disabled
                Application.targetFrameRate = 30;
        #endif
    }

    void Start()
    {
        Application.targetFrameRate = 30;
        if (!PlayerPrefs.HasKey("TutorialTO"))
        {
            PlayerPrefs.SetInt("TutorialTO", 0);
            Tutorial.SetActive(true);
            Detener();
        }
        else
        {
            Tutorial.SetActive(false);
            Iniciar();
        }

        if (PlayerPrefs.HasKey("RecordTO"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("RecordTO", 0);
        }
        tinicial = Tiempo;
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
                //Instantiate(ObjetoObstaculo[r], Spawn[r]);
                GameObject Objeto = Instantiate(ObjetoObstaculo[r]) as GameObject;
                Objeto.transform.position = Spawn[r].transform.position;
                Objeto.transform.SetParent(Spawn[r].transform.parent.gameObject.transform.parent);
                int r2 = Random.Range(0,2);
                if (r2 == 1)
                {
                    int r3 = Random.Range(0, 3);
                    GameObject Objeto2 = Instantiate(Items[r3]) as GameObject;
                    Objeto2.transform.position = ItemsSpawn[0].transform.position;
                }
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
        estado_game = false;
        Retro.SetActive(true);
        puntajef.text = Puntos + "";
        if (Puntos > PlayerPrefs.GetInt("RecordTO"))
        {
            PlayerPrefs.SetInt("RecordTO", Puntos);
        }
        puntajel.text = PlayerPrefs.GetInt("RecordTO") + "";
    }

    public void Puntuar()
    {
        Puntos++;
        GameObject AnimaPuntaje = Instantiate(AnimacionPuntaje) as GameObject;
        AnimaPuntaje.transform.SetParent(Puntos_t.transform.parent);
        AnimaPuntaje.SetActive(true);
        AnimaPuntaje.transform.localPosition = Puntos_t.transform.localPosition;
        AnimaPuntaje.transform.localRotation = Puntos_t.transform.localRotation;
        AnimaPuntaje.transform.localScale = Puntos_t.transform.localScale;
        AnimaPuntaje.gameObject.GetComponent<Animator>().Play("Puntaje");
        Puntosanim.GetComponent<Animator>().Play("PuntageAnim");
        Destroy(AnimaPuntaje, 1f);
    }

    public void Reiniciar(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void Volver(string scena)
    {
        PlayerPrefs.SetString("ScenaActual", scena);
        SceneManager.LoadScene("Transcicion");
    }
}

