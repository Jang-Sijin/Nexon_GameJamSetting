using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mono.Cecil.Cil;
using UnityEngine;

namespace Manager
{
    // ※ SoundManager 사용법: Managers.SoundManager.Play(Define.Sound type, string path → 오디오 파일 경로, float pitch = 1.0f)
    public class SoundManager : MonoBehaviour
    {
        // 사운드 오디오 소스
        private AudioSource[] _audioSources = new AudioSource[(int) Define.Sound.MaxCount];

        // 사운드 오브젝트 이름
        private const string _soundObjName = "@Sound";
        
        public void Init()
        {
            // 사운드 오브젝트 찾기
            GameObject root = GameObject.Find(_soundObjName);
            
            // 사운드 오브젝트 없으면
            if (root == null)
            {
                // 사운드 오브젝트 생성 후 삭제X
                root = new GameObject {name = _soundObjName};
                Object.DontDestroyOnLoad(root);
                
                // 사운드 이름 목록들을 추출한다.
                string[] soundName = System.Enum.GetNames(typeof(Define.Sound));

                // 사운드 개수만큼 사운드 오브젝트 객체 하위에 추가 [계층구조]
                for (int i = 0; i < soundName.Length - 1; i++)
                {
                    GameObject go = new GameObject {name = soundName[i]};
                    go.transform.parent = root.transform;
                }

                // BGM 오디오 소스는 무한 재생으로 설정한다.
                _audioSources[(int)Define.Sound.Bgm].loop = true;
            }
        }

        // path: 파일 위치, pitch: 재생 속도
        public void Play(Define.Sound type, string path, float pitch = 1.0f)
        {
            if (path.Contains("Sounds/") == false)
                path = $"Sounds/{path}";

            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.Log($"[장시진] AudioClip Missing! → path:{path}");
                return;
            }
            
            switch (type)
            {
                case Define.Sound.Bgm:
                    // TODO
                    break;
                case Define.Sound.Effect:
                    // [사운드 이팩트]
                    AudioSource audioSource = _audioSources[(int) Define.Sound.Effect];
                    audioSource.pitch = pitch;
                    audioSource.PlayOneShot(audioClip);
                    break;
                default:                    
                    break;
            }
        }
    }
}