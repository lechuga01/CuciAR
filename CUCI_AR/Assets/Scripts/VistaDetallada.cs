using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaDetallada : MonoBehaviour {

	string[] items;
	public GameObject Materia;
	public GameObject HoraInicio;
	public GameObject HoraFinal;
	public GameObject Profesor;

	IEnumerator Start () {
		WWW itemData = new WWW ("http://localhost/AumentedReality/ItemData.php");
		yield return itemData;
		string itemDataString = itemData.text;
		items = itemDataString.Split(';');
		print(GetDataValue(items[0], "Profesor"));
		var DetallesMateria="";
		var DetallesHorarInicio="";
		var DetallesHoraFinal = "";
		var DetallesProfesor = "";
		
		DetallesMateria = GetDataValue(items[0],"Materia");
		DetallesHorarInicio = GetDataValue (items [0], "HorarioInicial");
		DetallesHoraFinal = GetDataValue (items [0], "HorarioFinal");
		DetallesProfesor = GetDataValue (items [0], "Profesor");
			  
		Materia.GetComponent<TextMesh>().text = DetallesMateria.ToString();
		HoraInicio.GetComponent<TextMesh>().text = DetallesHorarInicio.ToString();
		HoraFinal.GetComponent<TextMesh>().text = DetallesHoraFinal.ToString();
		Profesor.GetComponent<TextMesh>().text = DetallesProfesor.ToString();
	}

	string GetDataValue(string dato, string index){
		var valor = dato.Substring(dato.IndexOf(index) + index.Length);
		if(valor.Contains("|")) valor = valor.Remove(valor.IndexOf("|"));
		return valor;
	}
}
