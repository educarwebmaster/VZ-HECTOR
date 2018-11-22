using UnityEngine;
using System.Collections;

[System.Serializable]
public class Siguiente
{
    public GameObject Caminado;
    public string AnimacionCaminar;
    public GameObject Rastro;
    public GameObject Boton;
    public float Tiempo;
}

public class CAMINADO_M2_U2 : MonoBehaviour {

    public Siguiente[] Elementos;
    private int i;

    public void SiguienteAnimacion(int j)
    {
        i = j;
        StopCoroutine("Siguiente");
        StartCoroutine("Siguiente");
    }

    public IEnumerator Siguiente()
    {
        for (int j = 0; j < Elementos.Length; j++)
        {
            Elementos[j].Boton.SetActive(false);
            Elementos[j].Caminado.SetActive(false);
            Elementos[j].Rastro.SetActive(false);
        }

        Elementos[i].Boton.SetActive(true);
        Elementos[i].Caminado.SetActive(true);
        Elementos[i].Caminado.GetComponent<Animator>().Play("1");
        yield return new WaitForSeconds(Elementos[i].Tiempo);
        Elementos[i].Rastro.SetActive(true);
    }


}