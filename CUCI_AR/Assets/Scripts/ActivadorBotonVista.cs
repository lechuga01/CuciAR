using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorBotonVista : MonoBehaviour {

	
	 bool cambio=true;
     GameObject vistaNormal=null;
     GameObject vistaDetallada=null;
   
    public void setVistas(GameObject vistaN, GameObject vistaD){
        this.vistaNormal = vistaN;
        this.vistaDetallada = vistaD;
    }

    private void Update()
    {
        if (cambio == true)
        {
            vistaDetallada.SetActive(false);
            vistaNormal.SetActive(true);

        }
        else
        {
            vistaNormal.SetActive(false);
            vistaDetallada.SetActive(true);
        }
    }
    public void CambioVistas(){
		if (cambio == false) {
			cambio = true;

		} else if (cambio == true) {
			cambio = false;
		}

	}

}
