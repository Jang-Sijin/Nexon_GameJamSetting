using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static SceneManager SceneManager;
    public static SoundManager SoundManager; 
    
    #region 싱글톤
    public static Managers Instance
    {
        get
        {
            Init();
            return s_instance;
        }
    }
    private static Managers s_instance;
    private const string _name = "@Managers";
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject goManagers = GameObject.Find(_name);
            if (goManagers == null)
            {
                goManagers = new GameObject {name = _name};
                goManagers.AddComponent<Managers>();
            }
            
            DontDestroyOnLoad(goManagers);
            s_instance = goManagers.GetComponent<Managers>();
        }
    }
}