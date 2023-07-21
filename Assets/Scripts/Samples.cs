using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class Samples : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    // Update is called once per frame
    void Start()
    {
        // Managers.Sound.Play(_audioClip, Define.Sound.Bgm);
    }
}
