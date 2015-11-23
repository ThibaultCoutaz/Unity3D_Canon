using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject target;
    public GameObject Spawn;
    bool spawndone = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(spawndone==true)
            StartCoroutine("SpawnTarget");
	}

    IEnumerator SpawnTarget()
    {
        GameObject shot = Instantiate(target, Spawn.transform.position, transform.rotation) as GameObject;
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.velocity = transform.TransformVector(new Vector3(0, 0, -1)) * 0.5f;
        spawndone = false;
        yield return new WaitForSeconds(3f);
        spawndone = true;
    }
}
