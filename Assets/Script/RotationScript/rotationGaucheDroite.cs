using UnityEngine;
using System.Collections;

public class rotationGaucheDroite : MonoBehaviour {

    float turnSpeed = 50f;
    public float RayonShoot;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Rotation Gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-1,0), turnSpeed * Time.deltaTime,Space.World);
        }
        //Rotation Droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0), turnSpeed * Time.deltaTime,Space.World);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float theta  = 0;
        float x = RayonShoot * Mathf.Cos(theta);
        float y = RayonShoot * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, 0, y);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = RayonShoot * Mathf.Cos(theta);
            y = RayonShoot * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }

    //Pour les cacules au niveau de la physique
    //void FixedUpdate(){


    //}
}
