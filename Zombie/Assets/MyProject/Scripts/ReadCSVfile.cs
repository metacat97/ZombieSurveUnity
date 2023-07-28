using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SearchService;
using UnityEngine;

public class ReadCSVfile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile();
        //StreamReader sr = new StreamReader(Application.dataPath + "/" + "ZombieSurvivalDatas.csv");
        //Debug.Log(Application.dataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReadCSVFile()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "\\MyProject\\Resources\\ZombieDatas\\ZombieSurvivalDatas.csv");
            //("C:\\Users\\KGA\\UnityWorks\\Day8\\main\\Zombie\\Assets\\MyProject\\Resources\\ZombieDatas\\ZombieSurvivalDatas.csv");

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            for (int i = 0; i < data_values.Length; i++)
            {
                Debug.Log("v: " + i.ToString() + " " + data_values[i].ToString());
            }
        }

    }
}
