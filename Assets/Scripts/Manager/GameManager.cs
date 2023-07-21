using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
        }

        public void StartBtn()
        {
            // BGM을 페이드 아웃합니다.
            MasterAudio.FadeOutAllOfSound("Lobby", 3);
            Managers.Scene.LoadScene(Define.Scene.InGame);
            MasterAudio.PlaySoundAndForget("InGame", 3);
        }
    }
}