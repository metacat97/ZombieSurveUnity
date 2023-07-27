//using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;   <-- 이거 빌드가 안될 때가 있어여

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
    private static string zombieDataPath = default;
    public ZombieData zombieData_default = default;
    private void Awake()
    {
        //dataPath = Application.dataPath;
        //zombieDataPath = string.Format("{0} / {1}", Application.dataPath, "MyProject/SctiptableData");
        //byte[] byteZombieData = File.ReadAllBytes(zombieDataPath + "/Zombie Default");//System.IO.
        //ZombieData zombieData = default;

        //zombieDataPath = "Assets/MyProject/SctiptableData";
        
        
        zombieDataPath = "SctiptableData";
        zombieDataPath = string.Format("{0}/{1}", zombieDataPath, "Zombie Default");
        zombieData_default = Resources.Load<ZombieData>(zombieDataPath);

        Debug.LogFormat("게임 Save data를 여기에다가 저장하는 것이 상식이다 -> {0}", Application.persistentDataPath);

        //ZombieData zombieData_ = AssetDatabase.LoadAssetAtPath<ZombieData>(zombieDataPath);

        //Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
        //Debug.LogFormat("Zombie data path : {0}, {1}, {2}", health , damage,    speed);


       // Debug.LogFormat("Zombie data path : {0}", zombieDataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
