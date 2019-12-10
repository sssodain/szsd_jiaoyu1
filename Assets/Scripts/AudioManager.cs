using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null) _instance = (new GameObject("AudioManager")).AddComponent<AudioManager>();
            return _instance;
        }
    }

    Dictionary<string, AudioClip> AudioClipDic = new Dictionary<string, AudioClip>();

    public AudioClip GetAudioClip(string name, SoundType soundType)
    {
        AudioClip res = null;
        if (AudioClipDic.ContainsKey(name))
        {
            res = AudioClipDic[name];
        }
        else
        {
            string path = "EnvironmentalSound/" + soundType + "/" + name;
            Object obj = Resources.Load(path);
            if (obj == null)
            {
                Debug.LogError("错误:请检查有没有这个声音文件"+ path);
                return null;
            }

            res = obj as AudioClip;
            AudioClipDic.Add(name, res);
        }
        return res;
    }

    public AudioClip GetAudioClip(string name,string path)
    {
        AudioClip res = null;
        if (AudioClipDic.ContainsKey(name))
        {
            res = AudioClipDic[name];
        }
        else
        {
            path += ("/" + name);
            Object obj = Resources.Load(path);
            if (obj == null)
            {
                Debug.LogError("错误:请检查有没有这个声音文件" + path);
                return null;
            }

            res = obj as AudioClip;
            AudioClipDic.Add(name, res);
        }
        return res;
    }

    List<AudioSource> AudioSourceList = new List<AudioSource>();
    private AudioSource GetAudioSource()
    {
        for (int i = 0; i < AudioSourceList.Count; i++)
        {
            if (!AudioSourceList[i].isPlaying) return AudioSourceList[i];
        }

        AudioSource res = gameObject.AddComponent<AudioSource>();
        res.playOnAwake = false;
        AudioSourceList.Add(res);
        return res;
    }

    //播放2D声音
    public void PlayAudio(string AudioName, SoundType soundType, bool IsLoop = false,float volume = 1f)
    {
        AudioSource audioSource = GetAudioSource();
        audioSource.clip = GetAudioClip(AudioName, soundType);
        audioSource.loop = IsLoop;
        audioSource.volume = volume;
        audioSource.Play();
    }
    //播放3D声音
    public void Play3DAudio(AudioSource audioSource,string AudioName, SoundType soundType, bool IsLoop = false, float volume = 1f)
    {
        audioSource.clip = GetAudioClip(AudioName, soundType);
        audioSource.loop = IsLoop;
        audioSource.volume = volume;
        audioSource.Play();
    }
    //2D声音
    private void StopAudio(string AudioName)
    {
        for (int i = 0; i < AudioSourceList.Count; i++)
        {
            if (AudioSourceList[i].isPlaying && AudioSourceList[i].clip.name.Equals(AudioName))
            {
                AudioSourceList[i].Stop();
            }
        }
    }
    public float GetClipLength(string name, SoundType soundType)
    {
        AudioClip audioClip = GetAudioClip(name, soundType);
        return audioClip.length;
    }
}

public enum SoundType
{
    
}