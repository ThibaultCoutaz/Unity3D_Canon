using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay : MonoBehaviour
{

    public GameObject target;
    public GameObject Spawn;
    public GameObject MachinGun;
    bool spawndone = true;
    Rigidbody rb;
    public List<GameObject> TargetActive = new List<GameObject>();
    public List<GameObject> TargetInActive = new List<GameObject>();
    public int TailleMap;
    int[,] tabmap;
    /*value int
    *0 = place availaible
    *1 = place busy
    *2 = out of border
    *3 = on the target way
    */
    public Renderer size;
    public Camera c;
    float stepx;
    float stepz;


    // Use this for initialization
    void Start()
    {
        tabmap = new int[TailleMap, TailleMap];
        for (int i = 0; i < TailleMap; i++)
            for (int j = 0; j < TailleMap; j++)
                tabmap[i, j] = 0;


        stepx = size.bounds.size.x / TailleMap;
        stepz = size.bounds.size.z / TailleMap;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawndone == true)
            StartCoroutine("SpawnTarget");

        //if (Input.GetKey(KeyCode.A))
        //{
        //    GameObject.Find("MachinGun").GetComponent<rotationGaucheDroite>().automatique = true;
        //    GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
        //    GameObject.Find("Camera").GetComponent<Camera>().enabled = false;
        //}
        //else if (Input.GetKey(KeyCode.Z))
        //{
        //    GameObject.Find("MachinGun").GetComponent<rotationGaucheDroite>().automatique = false;
        //    GameObject.Find("MainCamera").GetComponent<Camera>().enabled=false;
        //    GameObject.Find("Camera").GetComponent<Camera>().enabled = true;
        //}
    }

    void OnMouseDown()
    {
        Ray ray = c.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        float tempx = 16f + hit.point.x;
        float tempxc = tempx / 1.6f;

        float tempz = 16f + hit.point.z;
        float tempzc = tempz / 1.6f;
        if(tabmap[(int)tempxc, (int)tempzc] != 1)
        {

            tabmap[(int)tempxc, (int)tempzc] = 1;
            MachinGun = Instantiate(MachinGun, new Vector3((int)tempxc * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, (int)tempzc * stepz - size.bounds.size.z / 2 + (stepz / 2)), transform.rotation) as GameObject;
            
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
            yield return new WaitForSeconds(2f);
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
            yield return new WaitForSeconds(2f);
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

    


    void OnDrawGizmos()
    {
        for (int i = 0; i < TailleMap; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector3(i * stepx - size.bounds.size.x / 2,0, size.bounds.size.z / 2), new Vector3(i * stepx - size.bounds.size.x / 2,0, -size.bounds.size.z / 2));
            Gizmos.DrawLine(new Vector3(size.bounds.size.x / 2,0, i * stepz - size.bounds.size.z / 2), new Vector3(-size.bounds.size.x / 2,0, i * stepz - size.bounds.size.z / 2));
            for (int j = 0; j < TailleMap; j++)
            {
                if (tabmap != null)
                    if (tabmap[i, j] == 1)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireSphere(new Vector3(i*stepx - size.bounds.size.x / 2 +(stepx/2), 0,j*stepz - size.bounds.size.z / 2+(stepz / 2)), 1);

                    }
            }
        }
        Gizmos.DrawLine(new Vector3(TailleMap * stepx - size.bounds.size.x / 2, 0, size.bounds.size.z / 2), new Vector3(TailleMap * stepx - size.bounds.size.x / 2, 0, -size.bounds.size.z / 2));
        Gizmos.DrawLine(new Vector3(size.bounds.size.x / 2, 0, TailleMap * stepz - size.bounds.size.z / 2), new Vector3(-size.bounds.size.x / 2, 0, TailleMap * stepz - size.bounds.size.z / 2));

    }
}
