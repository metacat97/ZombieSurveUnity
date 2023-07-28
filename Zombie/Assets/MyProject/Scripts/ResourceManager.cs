//using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using UnityEditor;   <-- �̰� ���尡 �ȵ� ���� �־

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager m_instance;
    public static ResourceManager instance
    {
        get 
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ResourceManager>();
            }

            return m_instance;
        }

    }

    //private string dataPath = default;
    //public ZombieData zombieData_default = default;
    private static string zombieDataPath = default;
    public ZombieData zombieDatas_default = default;

    public ZombieData[] zombieDatas = default;


    private void Awake()
    {
        zombieDatas = Resources.LoadAll<ZombieData>("SctiptableData");

        zombieDataPath = "ZombieDatas";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "ZombieSurvivalDatas");
        TextAsset csvFile = Resources.Load<TextAsset>(zombieDataPath) as TextAsset;
        
        //   Debug.LogFormat("������ ���� - >>> {0}  ,  �����ϴ� ��ġ�� ->>> {1}", csvFile, Application.dataPath);
        Debug.LogFormat("���� Save data�� ���⿡�ٰ� �����ϴ� ���� ����̴� -> {0}", Application.persistentDataPath);
        string[] zombieDataBeforeRow = csvFile.text.Split("\n");

        //Debug.LogFormat("�̰� ù��° >> {0}, \n�̰� �ι�°>>> {1}, \n ����° >>>{2},\n�׹�°>> {3}", zombieDataBeforeRow[0], zombieDataBeforeRow[1], zombieDataBeforeRow[2], zombieDataBeforeRow[3]);
        
        for(int i = 0; i < 3; i++)
        {
            string[] zombieDataBeforeCol = zombieDataBeforeRow[i+1].Split(",");
            zombieDatas[i].name = zombieDataBeforeCol[0];

            Debug.Log(zombieDataBeforeCol[1] + "��" + zombieDataBeforeCol[1].Length);
            Debug.Log(zombieDataBeforeCol[2] + "��(2)");
            Debug.Log(zombieDataBeforeCol[3] + "��(3)");

            zombieDatas[i].health = int.Parse(zombieDataBeforeCol[1]);
            zombieDatas[i].damage = int.Parse(zombieDataBeforeCol[2]);

            zombieDatas[i].speed =  int.Parse(zombieDataBeforeCol[3]);
            //ColorUtility.TryParseHtmlString("#"+ zombieDataBeforeCol[3].Substring(0, 6) + "FF", out zombieDatas[i].skinColor);


        }

        Debug.Log(zombieDatas.Length+"����");


        #region test�ߴ� �͵�
        //dataPath = Application.dataPath;
        //zombieDataPath = string.Format("{0} / {1}", Application.dataPath, "MyProject/SctiptableData");
        //byte[] byteZombieData = File.ReadAllBytes(zombieDataPath + "/Zombie Default");//System.IO.
        //ZombieData zombieData = default;

        //zombieDataPath = "Assets/MyProject/SctiptableData";


        //zombieDataPath = "SctiptableData";

        //zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Default");

        //zombieData_default = Resources.Load<ZombieData>(zombieDataPath);


        //ZombieData zombieData_ = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);

        //Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data path : {0}, {1}, {2}", health , damage,    speed);


        // Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
        #endregion
    }

 
}
