using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    void Awake()
    {
        MasterAudio.StartPlaylist("InGame");
    }
}
