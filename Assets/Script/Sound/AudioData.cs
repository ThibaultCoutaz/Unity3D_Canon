using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using Datas;

public class AudioData : MonoBehaviour {

    [SerializeField]
    AudioClip[] AudioClips;
    
    public Audio_Type AudioTypes;
    public AudioMixerGroup defaultMixerGroup;

    void Awake()
    {
        AudioController.instance.registerAudioData(AudioTypes, this);
    }

    public AudioClip getClip()
    {
        int index = Random.Range(0,AudioClips.Length);
        AudioClip clip = AudioClips[index];
        return clip;
    }


    //void OnDestroy()
    //{
    //    AudioManager.instance.registerAudioData(type, this);
    //}
}
