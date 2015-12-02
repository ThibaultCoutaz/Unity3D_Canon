using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectionLG : MonoBehaviour {

    public float RayonShootMax;
    public float RayonShootMin;
    public bool detect = false;
    public GameObject Plane;
    public GameObject pivotcanon;
    int MoreNear = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Detect();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float theta = 0;
        float x = RayonShootMax * Mathf.Cos(theta);
        float y = RayonShootMax * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, 0, y);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = RayonShootMax * Mathf.Cos(theta);
            y = RayonShootMax * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
        
        theta = 0;
        x = RayonShootMin * Mathf.Cos(theta);
        y = RayonShootMin * Mathf.Sin(theta);
        pos = transform.position + new Vector3(x, 0, y);
        newPos = pos;
        lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = RayonShootMin * Mathf.Cos(theta);
            y = RayonShootMin * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }

    //function to check if a target is in range
    public void Detect()
    {
        List<GameObject> cible = Plane.GetComponent<GamePlay>().TargetActive;
        float Rtarget = Plane.GetComponent<GamePlay>().target.GetComponent<SphereCollider>().radius; //to save the raduis of the Target
        bool test = true;
        if (cible.Count != 0)
            for (int i = 0; i < cible.Count; i++)
            {
                if (distanceVector(cible[i].transform.position, transform.position) < RayonShootMax + Rtarget)
                {
                    if (test == true)
                    {
                        MoreNear = i;
                        test = false;
                    }
                    
                    Vector3 temp = cible[MoreNear].transform.position;
                    temp.y = transform.position.y;
                    this.transform.LookAt(temp);

                    detect = true;
                }
                else
                {

                }
            }
    }

    float distanceVector(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y) + (b.z - a.z) * (b.z - a.z));
    }
}
