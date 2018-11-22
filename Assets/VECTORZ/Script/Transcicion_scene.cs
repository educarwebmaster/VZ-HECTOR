using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transcicion_scene : MonoBehaviour {
    private string NivelParaCargar;
    public float Tiempo;
    public Image Carga;
    private AsyncOperation Load;

    void Start()
    {
        //Reiniciar tutorial
        //PlayerPrefs.DeleteKey("TutorialMU");
        NivelParaCargar = PlayerPrefs.GetString("ScenaActual");
        StartCoroutine("Cargar");
    }

    void Update()
    {
        Carga.fillAmount += Time.deltaTime;
    }

    public IEnumerator Cargar()
    {
        Carga.fillAmount += Time.deltaTime;
        yield return new WaitForSeconds(Tiempo);
        Load = SceneManager.LoadSceneAsync(NivelParaCargar);
        Carga.fillAmount = Load.progress;
    }
}
