using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    public GameObject Plane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        print("END");
        Plane.GetComponent<GamePlay>().DisableTarget(col.gameObject, false);
    }
}
