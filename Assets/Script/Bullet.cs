using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        DestroyObject(gameObject);
    }
}
