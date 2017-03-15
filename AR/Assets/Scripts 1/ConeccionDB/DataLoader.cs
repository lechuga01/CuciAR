using UnityEngine;
using System.Collections;


public class DataLoader : MonoBehaviour {
	public GameObject Materia;
	public GameObject IdAula;
	public GameObject HoraInicio;
	// Use this for initialization
	string[] items;
	IEnumerator Start () {
		WWW itemData = new WWW ("http://localhost/AumentedReality/ItemData.php");
		yield return itemData;
		string itemDataString = itemData.text;
		//print (itemDataString+"hola wey");
		items = itemDataString.Split(';');
		/*Va a depender de que imagen se este mirando se llamara a la obtencion de la informacion
		dependiendo si es de la tabla de que se necesite buscar y la informacion		
		*falta la obtencion de la enviacion de un dato de aqui para la base de datos y obtener su recepcion de tal en el php
*/
		/** 
		 *Se creara la optimizacion para saber que tag tiene la vista desde aqui y para identificar que informacion se debe de mostrar
		 *en el texto NO EN EL DefaultTrackableEventHandler como se esperaba 
		 *
		*/
		var Materias = "";
		var IdAulas ="";
		var Hora = "";
		foreach (var item in items)
		{
			Materias = Materias + GetDataValue(item,"Materia") +"\n\n\n";
			IdAulas =GetDataValue(item,"idAula") ;
			Hora = Hora + GetDataValue (item, "HorarioInicial")+"\n\n";
			print(Materias);
			Materia.GetComponent<TextMesh>().text = Materias.ToString();
			IdAula.GetComponent<TextMesh>().text = IdAulas.ToString();
			HoraInicio.GetComponent<TextMesh> ().text = Hora.ToString ();
		}		
	}
	string GetDataValue(string dato, string index){
		var valor = dato.Substring(dato.IndexOf(index) + index.Length);
		if(valor.Contains("|")) valor = valor.Remove(valor.IndexOf("|"));
		return valor;
	}
}
