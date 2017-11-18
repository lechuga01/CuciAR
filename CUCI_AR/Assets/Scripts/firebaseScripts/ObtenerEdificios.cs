﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.IO;

public class ObtenerEdificios : MonoBehaviour {

	// Use this for initialization
    /**
     * obtencion de base de datos 
     * 
     * evaluacion de archivo txt existe:?aplicar informacion : descargar y crear archivo txt
     * 
     * 1-creacion archivo txt y escritura formato >|E|03|L|700|profesor|materia|*|800|profesor|materia|*....|M|700|profesor|materia|*|800|profesor|materia|*....|@|04......|salto de linea
>|C|..........'
     * 2-llenado con base de datos 
     * 3- evaluacion de conexion a internet
    */
	void Start () {
        Debug.Log(this.gameObject.name);//obtencion d nombre de gameobject asi otendremos el dato de que imagen es la vista

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://arcloud-udg.firebaseio.com/");//conexion a base de datos

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;//referencia a la base
       // reference.Child("TEST").SetValueAsync(2);
        Debug.Log("entro");

        FirebaseDatabase.DefaultInstance//creacion de instancia de obtencion de informacion referida a los hijos (llaves json)
                        .GetReference("Edificio")//.Child("E")//.Child("03").Child("L")//dependiendo el nombre se creara un parse para obtener informacion especifica
            .ValueChanged += HandleValueChanged;

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        Debug.Log(args.Snapshot.GetRawJsonValue());
        // WriteString(args.Snapshot.GetRawJsonValue());

       // Debug.Log(args.Snapshot.Value);
        Debug.Log(args.Snapshot.Key);
        int i = 700,x=0;
        long valor = args.Snapshot.ChildrenCount;
        materias[] m = new materias[valor];
        while(i != 1000){
            Debug.Log(args.Snapshot.Child(""+i).Child("materia").Value.ToString());
            m[x] =new materias(i,args.Snapshot.Child("" + i).Child("materia").Value.ToString(),args.Snapshot.Child("" + i).Child("profesor").Value.ToString());
            i += 100;
            x++;
        }
        x = 0;
        while (x != m.Length)
        {
            Debug.Log(m[x].gethora()+"materia: "+m[x].getmateria());


            x++;
        }
        Debug.Log(args.Snapshot.ChildrenCount.ToString());

    }
	
    static void WriteString(string cadena)
    {
        string path = "Assets/db.txt";

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(cadena);
        writer.Close();

    }
}
class materias//E0101
{
    int hora;
    string materia, profesor;
    public materias(int hora, string materia, string profesor)
    {
        this.hora = hora;
        this.materia = materia;
        this.profesor = profesor;
    }
    public int gethora()
    {
        return this.hora;
    }
    public string getmateria(){
        return this.materia;
    }
}