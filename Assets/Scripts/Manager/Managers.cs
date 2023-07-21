using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class Managers : MonoBehaviour
    {
        private SceneManagerEx _sceneManagerEx = new SceneManagerEx();
        private ResourceManager _resourceManager = new ResourceManager();
        
        public static SceneManagerEx Scene => Instance._sceneManagerEx;
        public static ResourceManager Resource => Instance._resourceManager;

        #region 싱글톤
        private const string _name = "@Managers";
        private static Managers s_instance = new Managers();
        public static Managers Instance
        {
            get
            {
                Init();
                return s_instance;
            }
        }
        #endregion
        
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
                
                // 사운드 매니저 초기화.
                //s_instance._soundManager.Init();
            }
        }
    }
}