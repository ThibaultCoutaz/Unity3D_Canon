using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay : MonoBehaviour
{

    public GameObject target;
    public GameObject Spawn;
    public GameObject End;
    public GameObject MachinGun;
    public GameObject LanceGrenade;
    bool spawndone = true;
    public List<GameObject> TargetActive = new List<GameObject>();
    public List<GameObject> TargetInActive = new List<GameObject>();
    public int TailleMap;
    public float SpeedTarget;
    int[,] tabmap;
    /*value int
    *0 = place availaible
    *1 = place busy
    *2 = out of border
    *3 = on the target way
    */
    public Renderer size;
    public Camera c;
    float stepx, stepz,halfTaillex,halfTaillez;
    Vector3 directionT;
    bool TargetWork = true;
    public GameObject TextMoney;
    float Money = 100;
    public GameObject TextLife;
    public float Life = 10;
    /*
    *0 = gatling
    *1 = lancegrenade
    */
    int weapon = 0; 

    public List<GameObject> TowerGatlActive = new List<GameObject>();
    public List<GameObject> TowerGatlInActive = new List<GameObject>();


    public List<GameObject> TowerGreActive = new List<GameObject>();
    public List<GameObject> TowerGreInActive = new List<GameObject>();


    // Use this for initialization
    void Awake()
    {
        tabmap = new int[TailleMap, TailleMap];
        for (int i = 0; i < TailleMap; i++)
            for (int j = 0; j < TailleMap; j++)
                tabmap[i, j] = 0;


        stepx = size.bounds.size.x / TailleMap;
        stepz = size.bounds.size.z / TailleMap;
        halfTaillex = size.bounds.size.x / 2 ;
        halfTaillez = size.bounds.size.z / 2;

        Vector3 spawn = Spawn.transform.position;
        Vector3 end = End.transform.position;

        directionT = new Vector3(end.x - spawn.x, end.y - spawn.y, end.z - spawn.z);
        directionT = Vector3.Normalize(directionT);

        TestWay(spawn,end);

        TowerGatlInActive.Add(MachinGun);
        TowerGreInActive.Add(LanceGrenade);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawndone == true)
            StartCoroutine("SpawnTarget");

        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine("FREEZE");

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (weapon == 0)
            {
                weapon = 1;
            }
            else if (weapon == 1)
            {
                weapon = 0;
            }
        }


        TargetProgress(TargetWork);

    }

    void OnMouseDown()
    {
        if (weapon ==0)
        {
            Ray ray = c.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            float tempx = halfTaillex + hit.point.x;
            float tempxc = tempx / stepx;

            float tempz = halfTaillez + hit.point.z;
            float tempzc = tempz / stepz;
            if (tabmap[(int)tempxc, (int)tempzc] != 1 && tabmap[(int)tempxc, (int)tempzc] != 3)
            {
                tabmap[(int)tempxc, (int)tempzc] = 1;

                if (TowerGatlInActive.Count == 0)
                {
                    MachinGun = Instantiate(MachinGun, new Vector3((int)tempxc * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, (int)tempzc * stepz - size.bounds.size.z / 2 + (stepz / 2)), transform.rotation) as GameObject;
                    TowerGatlActive.Add(MachinGun);
                }
                else
                {
                    TowerGatlInActive[0].transform.position = new Vector3((int)tempxc * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, (int)tempzc * stepz - size.bounds.size.z / 2 + (stepz / 2));
                    TowerGatlInActive[0].SetActive(true);
                    TowerGatlActive.Add(TowerGatlInActive[0]);
                    TowerGatlInActive.RemoveAt(0);
                }
                Money -= 10;
            }


        }else if(weapon == 1)
        {
            Ray ray = c.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            float tempx = halfTaillex + hit.point.x;
            float tempxc = tempx / stepx;

            float tempz = halfTaillez + hit.point.z;
            float tempzc = tempz / stepz;
            if (tabmap[(int)tempxc, (int)tempzc] != 1 && tabmap[(int)tempxc, (int)tempzc] != 3)
            {
                tabmap[(int)tempxc, (int)tempzc] = 1;

                if (TowerGreInActive.Count == 0)
                {
                    LanceGrenade = Instantiate(LanceGrenade, new Vector3((int)tempxc * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, (int)tempzc * stepz - size.bounds.size.z / 2 + (stepz / 2)), transform.rotation) as GameObject;
                    TowerGatlActive.Add(LanceGrenade);
                }
                else
                {
                    TowerGreInActive[0].transform.position = new Vector3((int)tempxc * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, (int)tempzc * stepz - size.bounds.size.z / 2 + (stepz / 2));
                    TowerGreInActive[0].SetActive(true);
                    TowerGreActive.Add(TowerGreInActive[0]);
                    TowerGreInActive.RemoveAt(0);
                }
                Money -= 50;
            }
        }


    }


    IEnumerator SpawnTarget()
    {
        if (TargetInActive.Count == 0)
        {
            GameObject targetPC = Instantiate(target, Spawn.transform.position, transform.rotation) as GameObject;
            targetPC.GetComponent<BehaviourTarget>().Plane = this.gameObject;
            TargetActive.Add(targetPC);
            spawndone = false;
            yield return new WaitForSeconds(2f);
            spawndone = true;
        }
        else
        {
            TargetInActive[0].transform.position = Spawn.transform.position;
            TargetInActive[0].GetComponent<BehaviourTarget>().Life = 4;
            TargetInActive[0].SetActive(true);
            TargetActive.Add(TargetInActive[0]);
            TargetInActive.RemoveAt(0);
            spawndone = false;
            yield return new WaitForSeconds(2f);
            spawndone = true;
        }
    }

    //*********Spell Freeze***********//
    IEnumerator FREEZE()
    {
        TargetWork = false;
        yield return new WaitForSeconds(3f);
        TargetWork = true;
    }

    //To put a BulletInactive
    public void DisableTarget(GameObject destroyTarget,bool destroy)
    {
        destroyTarget.SetActive(false);
        TargetInActive.Add(destroyTarget);
        TargetActive.Remove(destroyTarget);
        
        if (destroy) //mean that it was destroy from a bullet 
        {
            Money += 10;
            TextMoney.GetComponent<TextMesh>().text = "Money : "+Money+" Bananes";
        }
        else //Destroy wit arriving at the end
        {
            Life--;
            TextLife.GetComponent<TextMesh>().text = "Lifes : " + Life;
        }
    }

    //To switch a gatling to disable
    public void DisableGatling(GameObject destroyGatling)
    {
        destroyGatling.SetActive(false);
        TargetInActive.Add(destroyGatling);
        TargetActive.Remove(destroyGatling);
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
                {
                    if (tabmap[i, j] == 1)
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawWireSphere(new Vector3(i * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, j * stepz - size.bounds.size.z / 2 + (stepz / 2)), 1);

                    }
                    if(tabmap[i, j] == 3)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(new Vector3(i * stepx - size.bounds.size.x / 2 + (stepx / 2), 0, j * stepz - size.bounds.size.z / 2 + (stepz / 2)),new Vector3(stepx, 1, stepz));
                    }
                }
            }
        }
        Gizmos.DrawLine(new Vector3(TailleMap * stepx - size.bounds.size.x / 2, 0, size.bounds.size.z / 2), new Vector3(TailleMap * stepx - size.bounds.size.x / 2, 0, -size.bounds.size.z / 2));
        Gizmos.DrawLine(new Vector3(size.bounds.size.x / 2, 0, TailleMap * stepz - size.bounds.size.z / 2), new Vector3(-size.bounds.size.x / 2, 0, TailleMap * stepz - size.bounds.size.z / 2));

    }

    //***To define the way of the taregt like this we can't put tower there****//
    /////////PLEIN DE MODIF A FAIRE
    // 16 = size /2
    //1.6 = size / taillemap 
    void TestWay(Vector3 spawn,Vector3 end)
    {
        Vector3 test = spawn;
        
        if (spawn.x < end.x)
        {
            while (test.x < end.x)
            {
                test += directionT * 0.1f;

                float tempx = halfTaillex + test.x + target.GetComponent<SphereCollider>().radius;
                float tempxc = tempx / stepx;

                float tempz = halfTaillex + test.z + target.GetComponent<SphereCollider>().radius;
                float tempzc = tempz / stepz;
                if (tabmap[(int)tempxc, (int)tempzc] != 3)
                {
                    tabmap[(int)tempxc, (int)tempzc] = 3;
                }

                tempx = halfTaillex + test.x - target.GetComponent<SphereCollider>().radius;
                tempxc = tempx / stepx;

                tempz = halfTaillez + test.z - target.GetComponent<SphereCollider>().radius;
                tempzc = tempz / stepz;
                if (tabmap[(int)tempxc, (int)tempzc] != 3)
                {
                    tabmap[(int)tempxc, (int)tempzc] = 3;
                }


            }
        }else if (spawn.x > end.x)
        {
            while (test.x > end.x)
            {
                test += directionT * 0.1f;

                float tempx = 16f + test.x ;
                float tempxc = tempx / 1.6f;

                float tempz = 16f + test.z + target.GetComponent<SphereCollider>().radius;
                float tempzc = tempz / 1.6f;
                if (tabmap[(int)tempxc, (int)tempzc] != 3)
                {
                    tabmap[(int)tempxc, (int)tempzc] = 3;
                }

                tempz = 16f + test.z - target.GetComponent<SphereCollider>().radius;
                tempzc = tempz / 1.6f;
                if (tabmap[(int)tempxc, (int)tempzc] != 3)
                {
                    tabmap[(int)tempxc, (int)tempzc] = 3;
                }


            }
        }
    }

    //***Function to make the Target progressing , bool : to know if the player use the spell FREEZE****//
    void TargetProgress(bool TargetWork)
    {
        if(TargetWork)
            for(int i = 0; i < TargetActive.Count; i++)
            {

                TargetActive[i].transform.position += directionT * SpeedTarget;
            }
    }
}
