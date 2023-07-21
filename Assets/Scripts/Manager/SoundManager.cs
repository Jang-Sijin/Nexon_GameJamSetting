using System;
using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("#BGM Sound")]
    public AudioClip BgmClip;
    public float BgmVolumeValue;
    private AudioSource _bgmPlayer;

    [Header("#Effect Sound")]
    public AudioClip[] effectClips;
    public float effectVolumeValue;
    public int channels;
    private AudioSource[] _effectPlayers;
    private int _channelIndex;

    private const string _bgmPlayerSound = "BgmSound";
    private const string _effectPlayerSound = "effectSound";

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        // 1.배경음 사운드 초기화
        GameObject bgmGameObject = new GameObject(_bgmPlayerSound);
        bgmGameObject.transform.parent = transform;
        _bgmPlayer = bgmGameObject.AddComponent<AudioSource>();
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume = BgmVolumeValue;
        _bgmPlayer.clip = BgmClip;
        
        // 2.효과음 사운드 초기화
        GameObject effectGameObject = new GameObject(_effectPlayerSound);
        effectGameObject.transform.parent = transform;
        _effectPlayers = new AudioSource[channels];

        for (int index = 0; index < _effectPlayers.Length; index++)
        {
            _effectPlayers[index] = effectGameObject.AddComponent<AudioSource>();
            _effectPlayers[index].playOnAwake = false;
            _effectPlayers[index].volume = effectVolumeValue;
        }
    }
    
    public void PlayBGM(bool isPlay)
    {
        if (isPlay)
        {
            _bgmPlayer.Play();
        }
        else
        {
            _bgmPlayer.Stop();
        }
    }

    public void PlayEffectSound(Define.Sound sound)
    {
        for (int index = 0; index < _effectPlayers.Length; index++)
        {
            int loopIndex = (index + _channelIndex) % _effectPlayers.Length;
            
            if(_effectPlayers[loopIndex].isPlaying)
                continue;

            _channelIndex = loopIndex;
            _effectPlayers[loopIndex].clip = effectClips[(int) sound];
            _effectPlayers[loopIndex].Play();
        }
    }
}