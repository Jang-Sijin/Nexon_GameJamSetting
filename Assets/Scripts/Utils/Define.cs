using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        InGame
    }
    
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }
    
    // 프리팹 경로
    public const string BgmRoot = "BGM";
    public const string SoundRoot = "Sound";
    public const string PrefabsRoot = "Prefabs";
    public const string SoundManagerPrefabPath = PrefabsRoot + "/SoundManager";
    
    // 사운드 리소스
    public const string TitleBGM = "tam-n13";
    public const string MenuSelectSound = "decide1";
    public const string SelectSound = "Select";
}
