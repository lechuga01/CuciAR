using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.IO;
using UnityEngine.UI;
using System;

public class ObtenerEdificios : MonoBehaviour {

    // Use this for initialization
    /**
     * obtencion de base de datos 
     * 3- evaluacion de conexion a internet
     * obtener referencias de hijos atraves del nombre del gameobject
    */
    TextMesh Aula, Hora, Materia, Profesor, MateriaD, ProfesorD, DescripcionM;
    string datos;
    string EdificioLetra;
    string salon;
    string horaActual;
	void Start () {
        int dia;
        string gnombre = this.gameObject.name;
        Aula = GameObject.Find("/"+gnombre + "/Plano/Aula").GetComponent<TextMesh>();//metodo de busqueda del hijo por su nombre en el nombre del gameObject
        Aula.text =gnombre;//se coloca el nombre a aula
        Hora = GameObject.Find("/" + gnombre + "/Plano/Hora").GetComponent<TextMesh>();
        Materia = GameObject.Find("/"+gnombre + "/Plano/Materias").GetComponent<TextMesh>();
        Profesor = GameObject.Find("/" + gnombre + "/Plano/Profesor").GetComponent<TextMesh>();


        //Obtencion textmesh de vista Detalles
        ProfesorD = GameObject.Find("/" + gnombre + "/Detalles/Profesor").GetComponent<TextMesh>();
        MateriaD = GameObject.Find("/" + gnombre + "/Detalles/Materias").GetComponent<TextMesh>();
        DescripcionM = GameObject.Find("/" + gnombre + "/Detalles/Descripcion").GetComponent<TextMesh>();


        DateTime date = DateTime.Now;//obtiene la fecha y hora
        datos = date.Date.ToString();
        horaActual = date.Hour.ToString()+"00";//para darle un formato 900
        //Debug.Log("date: " + date);//date: 11/20/2017 11:24:40
        //Debug.Log("date: " + date.ToString("ddd"));// lansa el dia en ingles
        //Debug.Log("date: " + date.Hour);//date: nos da unicamente la hora sin minutos
        //Debug.Log("date: " + date.DayOfWeek);//date: lansa dia tambien en ingles en texto
        //Debug.Log("date: " + (int) date.DayOfWeek);//date: nos lanza el dia en digito lunes 1 martes 2 miercoles 3...
        //Debug.Log(this.gameObject.name);//obtencion d nombre de gameobject asi otendremos el dato de que imagen es la vista
        /**
         * falta seccionar codigo para la obtencion de datos referenciales a salon y edifico 
         * al igual que la hora fija del celular para mostrar 5 horas seguidas
        */
        //string gnombre = this.gameObject.name;
        dia = (int)date.DayOfWeek;
        EdificioLetra = gnombre[0].ToString();
        salon = gnombre.Substring(1);//son string porque la referencia a firebase son cadenas
        //Debug.Log(EdificioLetra);
        //Debug.Log(salon);

        String diaS="";
        switch(dia){//concatenacion de dia en cadena
            case 1:
                diaS = "L";
                break;
            case 2:
                diaS = "M";
                break;
            case 3:
                diaS = "I";
                break;
            case 4:
                diaS = "J";
                break;
            case 5:
                diaS = "V";
                break;
            case 6:
                diaS = "S";
                break;
        }
        //Debug.Log(diaS);
        //Debug.Log(horaActual);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://arcloud-udg.firebaseio.com/");//conexion a base de datos

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;//referencia a la base
       // reference.Child("TEST").SetValueAsync(2);
        //Debug.Log("entro");

        FirebaseDatabase.DefaultInstance//creacion de instancia de obtencion de informacion referida a los hijos (llaves json)
                        .GetReference("Edificio").Child(EdificioLetra).Child(salon)
                        //.Child(diaS)// es el dia actual 
                        .Child("L")//dependiendo el nombre se creara un parse para obtener informacion especifica
            .ValueChanged += HandleValueChanged;

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        string _profesor = "",_materia="",_hora="";
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        //Debug.Log(args.Snapshot.GetRawJsonValue());
        // WriteString(args.Snapshot.GetRawJsonValue());

       // Debug.Log(args.Snapshot.Value);

        //Debug.Log(args.Snapshot.Key);
        int i,x=0,J; //la i debe ser hora parseado a int 
        i = int.Parse(horaActual);
        J = i;
        //long valor = args.Snapshot.ChildrenCount;//crear dependiendo de la cantidad que obtendremos maximo 5 minimo 1 y lo demas colocarlo en null o ""
        int valor=0;
        if (J >= 1600)
        {//para reducir el valor de obtenciones de clases 
            Debug.Log("entro a la obtencion de horass");
            for (int y = J; y <= 2000; y += 100)
            {
                J += 100;
                valor++;
            }
        }else{//si es 1500 le aumentara a los 500 para haci tener limite de 2000
            J = i + 600;
            valor = 6;
        }

        DescripcionM.text = args.Snapshot.Child("" + i).Child("description").Value.ToString();//asigna texto de descripcion de la hora actual
        ProfesorD.text = args.Snapshot.Child("" + i).Child("profesor").Value.ToString();
        MateriaD.text = args.Snapshot.Child("" + i).Child("materia").Value.ToString();


        materias[] m = new materias[valor];
        while(i != J && i>=700 && i<=2000){//deve evaluar al mismo tiempo si i sea limite a 2000 y i mayor a 700  
            //if(){} si la i es igual a 2000 solamente mostrar 1 ves en lugar de +400 y asi desde 4 horas antes reducir 100 a la muestra 
            Debug.Log("entro a la obtencion");
            Debug.Log(args.Snapshot.Child(""+i).Child("materia").Value.ToString());
            //unicamente obtendra un Objeto con materia y con profesor
            m[x] =new materias(i,args.Snapshot.Child("" + i).Child("materia").Value.ToString(),args.Snapshot.Child("" + i).Child("profesor").Value.ToString());
            //colocar y crear una cadena con saltos de linea de cada seccion concatenada 
             _profesor = _profesor+ m[x].getprofesor() + "\n\n";
            _materia = _materia + m[x].getmateria()+"\n\n";
            _hora = _hora + m[x].gethora()+ "\n";

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
        Debug.Log("hora: " + _hora);
        Debug.Log("materias: "+_materia);
        Materia.text = _materia;
        Hora.text = _hora;
        Profesor.text = _profesor;
           
        /**
         *Falta seccionar y obtener de la hora actual a 4 mas de adelante solamente
         *
        **/
    }
	
   
}

class materias
{
    int hora;
    string materia, profesor;
    public materias(int hora, string materia, string profesor)
    {
        this.hora = hora;
        this.materia = materia;
        this.profesor = profesor;
        this.descripcion = descripcion;
    }
    public int gethora()
    {
        return this.hora;
    }
    public string getmateria(){
        return this.materia;
    }
    public string getprofesor()
    {
        return this.profesor;
    }
   
}