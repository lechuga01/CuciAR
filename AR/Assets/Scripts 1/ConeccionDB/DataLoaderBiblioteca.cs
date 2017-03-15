using UnityEngine;
using System.Collections;

public class DataLoaderBiblioteca : MonoBehaviour {
	public GameObject AutorText;
	public GameObject TituloUniforme;
	 string[] items;
	// Use this for initialization
	IEnumerator Start () {

		WWW itemData = new WWW ("http://localhost/AumentedReality/ItemBiblioteca.php");
		yield return itemData;
		string itemDataString = itemData.text;
		print (itemDataString+"BIBLIOTECA");
		items = itemDataString.Split('*');//se tiene que usar este signo ya que hay ; en algunos de los datos registrados por la base de la biblioteca
		var Autor="";
		var TUniforme = "";
		foreach (var item in items)
		{
			print(GetDataValue(item, "NoSistema")+" NOSIS");
			print(GetDataValue(item, "ISBN")+" ISBN");
			print(GetDataValue(item, "Autor"));
			print(GetDataValue(item, "TituloUniforme"));
			print(GetDataValue(item, "Titulo"));
			print(GetDataValue(item, "Edicion"));
			print(GetDataValue(item, "PieDeImprenta"));
			print(GetDataValue(item, "DescrFisica"));
			print(GetDataValue(item, "Nota"));
			print(GetDataValue(item, "TemaGeneral"));
			print(GetDataValue(item, "ASecPersonas"));
			print(GetDataValue(item, "BaseLogica"));
			Autor = Autor +GetDataValue(item, "Autor")+"\n\n\n";
			TUniforme = TUniforme + GetDataValue (item, "TituloUniforme")+"\n\n\n";
			AutorText.GetComponent<TextMesh>().text = Autor.ToString();
			TituloUniforme.GetComponent<TextMesh> ().text = TUniforme.ToString ();


		}
		/*print(GetDataValue(items[0],"NoSistema")+" NOSIS");
		print(GetDataValue(items[0],"ISBN")+" ISBN");
		print(GetDataValue(items[0],"Autor"));
		print(GetDataValue(items[0],"TUniforme"));
		print(GetDataValue(items[0], "Titulo"));
		print(GetDataValue(items[0], "Edicion"));
		print(GetDataValue(items[0], "PieDeImprenta"));
		print(GetDataValue(items[0], "DescrFisica"));
		print(GetDataValue(items[0], "Nota"));
		print(GetDataValue(items[0],"TemaGeneral"));
		print(GetDataValue(items[0],"ASecPersonas"));
		print(GetDataValue(items[0],"BaseLogica"));*/

		
		/*char[] period = {'|'};
		itemDataString = itemDataString.TrimEnd(period);
		string[] allNames = itemDataString.Split('*');

		Debug.Log(allNames[0]);
		string x="";
		for (int i = 0; i < allNames.Length; i++) {
		
			x = x + allNames [i]+"\n";

		}*/
	}

	string GetDataValue(string dato, string index){
		var valor = dato.Substring(dato.IndexOf(index) + index.Length);
		if(valor.Contains("|")) valor = valor.Remove(valor.IndexOf("|"));
		return valor;

	}

}
