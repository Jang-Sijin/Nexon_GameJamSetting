using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class Managers : MonoBehaviour
    {
        private SceneManagerEx _sceneManagerEx = new SceneManagerEx();
        private SoundManager _soundManager = new SoundManager();
        private ResourceManager _resourceManager = new ResourceManager();
        
        public static SceneManagerEx Scene
        {
            get { return Instance._sceneManagerEx; }
        }
        public static SoundManager Sound
        {
            get { return Instance._soundManager; }
        }
        public static ResourceManager Resource
        {
            get { return Instance._resourceManager; }
        }

        #region 싱글톤
        private const string _name = "@Managers";
        private static Managers s_instance;
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
                s_instance._soundManager.Init();
            }
        }
    }
}