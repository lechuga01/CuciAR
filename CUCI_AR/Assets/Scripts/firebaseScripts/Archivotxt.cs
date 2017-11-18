using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Archivotxt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //WriteString();
        ReadString();
	}
	
    static void WriteString(){
        string path = "Assets/db.txt";

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test1");
        writer.Close();

    }

    static void ReadString()
    {
        string path = "Assets/db.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string s = reader.ReadLine();
        if(s != ""){
            Debug.Log(s.Substring(3));
            Debug.Log(s.Substring(1,3));
            Debug.Log(s.IndexOf('t'));
        }
        string x = reader.ReadLine();//lee la siguiente linea
        Debug.Log(s);
        Debug.Log("-----"+x);
        reader.Close();
    }
}
