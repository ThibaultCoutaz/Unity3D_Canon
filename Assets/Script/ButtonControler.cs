using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour {

    public enum ButtonTypes {Sound, Freeze }
    public ButtonTypes type;

    public Sprite mute;
    public Sprite demute;
    //public GameObject cam;
    SoundControl sound;
    // Use this for initialization
    void Start () {
        sound = Camera.main.GetComponent<SoundControl>();
        if(mute!=null && demute != null)
        {
            bool ismute = (PlayerPrefs.GetInt("IS_MUTE")==1)? true : false;
            SetMuteImage(ismute);
            if (sound != null) sound.ForceMute(ismute);
        }
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        if (sound == null) return;

        switch (type)
        {
            case ButtonTypes.Sound:
                sound.toggleMute();
                SetMuteImage(sound.IsMute());
                PlayerPrefs.SetInt("IS_MUTE", sound.IsMute() ? 1 : 0);
                break;

            case ButtonTypes.Freeze:

                break;
        }
    }

    void SetMuteImage(bool a)
    {
        if (a)
        {
            GetComponent<Image>().overrideSprite = mute;
        }
        else
        {
            GetComponent<Image>().overrideSprite = demute;
        }
    }
}
