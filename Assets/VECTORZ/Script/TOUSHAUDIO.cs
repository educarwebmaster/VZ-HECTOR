using UnityEngine;
using System.Collections;

public class TOUSHAUDIO : MonoBehaviour {

    public AudioClip Audio;
    public AudioSource AudioControler;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnMouseDown()
    {
        AudioControler.PlayOneShot(Audio);
    }

}
