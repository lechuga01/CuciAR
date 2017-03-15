using UnityEngine;
using System.Collections;

public class CambiarColor : MonoBehaviour {
	public Material material1;
	public Material material2;
	private bool cambio=false;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material = material1;
		cambio = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cambio == true) {
			gameObject.GetComponent<Renderer> ().material = material2;
		} else {
			gameObject.GetComponent<Renderer> ().material = material1;
		}
	}

	public void cambioMaterial(){
		if (cambio == false) {
			cambio = true;
		} else if (cambio == true) {
			cambio = false;
		}

	}
}
