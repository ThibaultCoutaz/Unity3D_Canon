using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float Speed;
    public float SpeedShot;
    private float time =1;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            if (time > SpeedShot)
            {
                GameObject shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                Rigidbody rb = shot.GetComponent<Rigidbody>();
                rb.velocity = transform.TransformVector(new Vector3(0, -1, 0)) * Speed;
                time = 0;
            }
            else
            {
                time+=Time.deltaTime;
            }
        }
        
    }
}
