using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class SceneManagerEx
    {
        // 이전 씬
        public BaseScene CurrentScene => GameObject.FindObjectOfType<BaseScene>();
        
        public void LoadScene(Define.Scene type)
        {
            // CurrentScene.Clear();
            SceneManager.LoadScene(GetSceneName(type));
        }

        public string GetSceneName(Define.Scene type)
        {
            string sceneName = System.Enum.GetName(typeof(Define.Scene), type);
            return sceneName;
        }
    }
}
