using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CUBOS_M5_U1 : MonoBehaviour {
    public GameObject[] ElementoAactivar;

    void Start()
    {
        
    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine("Iniciar");
        }
    }

    public IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(6f);
        for (int i = 0;i < ElementoAactivar.Length;i++)
        {
            ElementoAactivar[i].SetActive(true);
        }
    }
}
