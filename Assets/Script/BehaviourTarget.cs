using UnityEngine;
using System.Collections;

public class BehaviourTarget : MonoBehaviour {

    public int Life = 4;
    public ParticleSystem explosion;
    public GameObject Plane;
    public bool shield;
    public GameObject shieldMesh;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        shield = true;
        shieldMesh.SetActive(shield);
        if (Random.Range(0, 100) < 0)
        {
            shield = false;
            shieldMesh.SetActive(shield);
            print("squalala");
            target.GetComponent<HingeJoint>().useMotor = false;
        }
    }

	// Update is called once per frame
	void Update () {
        if(shield == false)
        {
            shieldMesh.SetActive(shield);
        }
    }
    
}
