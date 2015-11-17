using UnityEngine;
using System.Collections;

public class RotationTire : MonoBehaviour {


    Vector3 rotate = new Vector3(0, 1, 0);
    public ParticleSystem FireShoot;


    public Rigidbody Bullet;

    public float Speed = 5;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {




        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(rotate, 15f, Space.Self);

            FireShoot.Play();

            Rigidbody instanciatedBullet = Instantiate(Bullet,new Vector3(-0.148f,0.968f,-2.143f), Quaternion.identity) as Rigidbody;
            instanciatedBullet.transform.Rotate(rotate);
            instanciatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));

            instanciatedBullet = Instantiate(Bullet,new Vector3(0.16f,0.968f,-2.143f), Quaternion.identity) as Rigidbody;
            instanciatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));

            instanciatedBullet = Instantiate(Bullet,new Vector3(0f, 0.807f, -2.1453f), Quaternion.identity) as Rigidbody;
            instanciatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));

            instanciatedBullet = Instantiate(Bullet,new Vector3(0f,1.109f,-2.143f), Quaternion.identity) as Rigidbody;
            instanciatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));

        }

    }
}
