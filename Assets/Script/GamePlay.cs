using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay : MonoBehaviour
{

    public GameObject target;
    public GameObject Spawn;
    bool spawndone = true;
    Rigidbody rb;
    public List<GameObject> TargetActive = new List<GameObject>();
    public List<GameObject> TargetInActive = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawndone == true)
            StartCoroutine("SpawnTarget");

        if (Input.GetKey(KeyCode.A))
        {
            GameObject.Find("MachinGun").GetComponent<rotationGaucheDroite>().automatique = true;
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
            GameObject.Find("Camera").GetComponent<Camera>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            GameObject.Find("MachinGun").GetComponent<rotationGaucheDroite>().automatique = false;
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled=false;
            GameObject.Find("Camera").GetComponent<Camera>().enabled = true;
        }
    }

    IEnumerator SpawnTarget()
    {
        if (TargetInActive.Count == 0)
        {
            target = Instantiate(target, Spawn.transform.position, transform.rotation) as GameObject;
            rb = target.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformVector(new Vector3(0, 0, -1)) * 0.5f;
            TargetActive.Add(target);
            spawndone = false;
            yield return new WaitForSeconds(3f);
            spawndone = true;
        }
        else
        {
            TargetInActive[0].transform.position = Spawn.transform.position;
            rb = TargetInActive[0].GetComponent<Rigidbody>();
            rb.velocity = transform.TransformVector(new Vector3(0, 0, -1)) * 0.5f;
            TargetInActive[0].GetComponent<BehaviourTarget>().Life = 2;
            TargetInActive[0].SetActive(true);
            TargetActive.Add(TargetInActive[0]);
            TargetInActive.RemoveAt(0);
            spawndone = false;
            yield return new WaitForSeconds(3f);
            spawndone = true;
        }
    }

    //To put a BulletInactive
    public void DisableTarget(GameObject destroyTarget)
    {
        destroyTarget.SetActive(false);
        TargetInActive.Add(destroyTarget);
        TargetActive.Remove(destroyTarget);
    }
}
