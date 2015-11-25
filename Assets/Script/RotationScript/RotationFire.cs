using UnityEngine;
using System.Collections;

public class RotationFire : MonoBehaviour {


    Vector3 rotate = new Vector3(0, 1, 0);
    public ParticleSystem FireShoot;

    public Transform Bullet;
    public float Speed = 5;


    // Use this for initialization
    void Start () {
        
    }

    //Function to fire a bullet
    void Fire()
    {
        transform.Rotate(rotate, 15f, Space.Self);
        FireShoot.Play();
    }
	
	// Update is called once per frame
	void Update () {
           
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }

    }
}
