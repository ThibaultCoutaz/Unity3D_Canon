using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour {

    public enum ButtonTypes {Sound, Freeze }
    public ButtonTypes type;

    public Sprite mute;
    public Sprite demute;


    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
       
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
