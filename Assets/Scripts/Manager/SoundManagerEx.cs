using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    // ※ SoundManager 사용법: Managers.SoundManager.Play(Define.Sound type, string path → 오디오 파일 경로, float pitch = 1.0f)
    public class SoundManagerEx : MonoBehaviour
    {
        // MP3 Player  -> AudioSource
        // MP3 음원     -> AudioClip
        // 관객(귀)     -> AudioListener

        // 사운드 오디오 소스
        private AudioSource[] _audioSources = new AudioSource[(int) Define.Sound.MaxCount];

        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

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
                Debug.Log(_audioSources[(int)Define.Sound.Bgm]);
                // _audioSources[(int)Define.Sound.Bgm].loop = true;
            }
        }
        
        public void Clear()
        {
            foreach (AudioSource audioSource in _audioSources)
            {
                audioSource.clip = null;
                audioSource.Stop();
            }
            _audioClips.Clear();
        }

        // path: 파일 위치, type: 사운드 타입, pitch: 재생 속도
        public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
        {
            AudioClip audioClip = GetOrAddAudioClip(path, type);
            Play(audioClip, type, pitch);
        }

        // path: 파일 위치, pitch: 재생 속도
        public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
        {
            if (audioClip == null)
                return;

            AudioSource audioSource = new AudioSource();
            switch (type)
            {
                case Define.Sound.Bgm:
                    // [배경음 사운드]
                    audioSource = _audioSources[(int)Define.Sound.Bgm];
                    if (audioSource.isPlaying)
                        audioSource.Stop();

                    audioSource.pitch = pitch;
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    break;
                case Define.Sound.Effect:
                    // [이팩트 사운드] 
                    audioSource = _audioSources[(int) Define.Sound.Effect];
                    audioSource.pitch = pitch;
                    audioSource.PlayOneShot(audioClip);
                    break;
                default:
                    break;
            }
        }

        AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
        {
            if (path.Contains("Sounds/") == false)
                path = $"Sounds/{path}";

            AudioClip audioClip = null;

            if (type == Define.Sound.Bgm)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
            }
            else
            {
                if (_audioClips.TryGetValue(path, out audioClip) == false)
                {
                    audioClip = Managers.Resource.Load<AudioClip>(path);
                    _audioClips.Add(path, audioClip);
                }
            }

            if (audioClip == null)
                Debug.Log($"[장시진] AudioClip Missing ! {path}");

            return audioClip;
        }
    }
}