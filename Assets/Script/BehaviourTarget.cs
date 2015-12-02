using UnityEngine;
using System.Collections;

public class BehaviourTarget : MonoBehaviour {

    public int Life = 4;
    public ParticleSystem explosion;
    public GameObject Plane;
    public bool shield = false;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (Life == 0)
        //{
        //    explosion.Play();
        //    Destroy(explosion, 1f);
        //}
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "End")
        {
            Plane.GetComponent<GamePlay>().DisableTarget(this.gameObject, false);
        }
    }
}
