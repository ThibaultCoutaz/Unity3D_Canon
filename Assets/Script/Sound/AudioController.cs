using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Datas;

public class AudioController : MonoBehaviour {

    #region Singleton Stuff
    private static AudioController _instance = null;
    private static readonly object singletonLock = new object();
    #endregion


    public static AudioController instance
    {
        get
        {
            lock (singletonLock)
            {
                if (_instance == null)
                {
                    _instance = (AudioController)FindObjectOfType<AudioController>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = "AudioManager";

                        _instance = obj.AddComponent<AudioController>();
                    }

                    DontDestroyOnLoad(_instance.gameObject);

                    _instance.Init();
                }

                return _instance;
            }
        }
    }

    private List<AudioClip> AudioClipActive;
    private List<AudioClip> AudioClipInActive;
    private Dictionary<Audio_Type, AudioData> AudioDatas;

    void Init()
    {
        AudioClipActive = new List<AudioClip>();
        AudioClipInActive = new List<AudioClip>();
        AudioDatas
    }

    public void registerAudioData(Audio_Type type, AudioData data)
    {
        AudioDatas.Add(type, data);
    }

    public void playAudio(Audio_Type type)
    {
        AudioSource source;
        AudioDatas[type].getClip();
        int key;
        
    }

    // Update is called once per frame
    void Update () {
	
	}
}
