using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {

    public AudioClip ambient;

	// Use this for initialization
	void Start () {
        
        PlayLoop(0.5f,ambient);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(float vol,AudioClip clip)
    {
        this.GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().volume = vol;
        GetComponent<AudioSource>().Play();
    }

    public void PlayLoop(float vol, AudioClip clip)
    {
        this.GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().volume = vol;
        GetComponent<AudioSource>().loop=true;
        GetComponent<AudioSource>().Play();
    }

    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }


    public void Pause()
    {
        GetComponent<AudioSource>().Pause(); 
    }

    public void toggleMute()
    {

        if (GetComponent<AudioSource>().mute)
        {
            GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GetComponent<AudioSource>().mute = true;
        }
    }

    public bool IsMute()
    {
        return GetComponent<AudioSource>().mute;
    }

    public void ForceMute(bool IsMute)
    {
        GetComponent<AudioSource>().mute = IsMute;
    }
}
