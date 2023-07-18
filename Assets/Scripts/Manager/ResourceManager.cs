using UnityEngine;

namespace Manager
{
    public class ResourceManager
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject prefab = Load<GameObject>($"Prefabs/{path}");

            if (prefab == null)
            {
                Debug.Log($"[장시진] Failed to load prefab! → path:{path}");
                return null;
            }

            return Object.Instantiate(prefab, parent);
        }

        public void Destroy(GameObject go, float delayTime = 0.0f)
        {
            if (go == null)
                return;
            
            Object.Destroy(go, delayTime);
        }
    }   
}
