using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorBotonVista : MonoBehaviour {

	public GameObject VistaNormal;
	public GameObject VistaDetallada;
	private bool cambio=false;

	void Start () {
		VistaNormal.SetActive(true);
		VistaDetallada.SetActive(false);
		cambio=true;
	}
	
	void Update () {
		if(cambio == true) {
			VistaDetallada.SetActive(false);
			VistaNormal.SetActive(true);
			
		} else {
			VistaNormal.SetActive(false);
			VistaDetallada.SetActive(true);
		}
	}

	public void CambioTextos(){
		if (cambio == false) {
			cambio = true;
		} else if (cambio == true) {
			cambio = false;
		}

	}
}
