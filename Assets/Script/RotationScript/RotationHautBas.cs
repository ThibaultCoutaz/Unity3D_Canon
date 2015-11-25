using UnityEngine;
using System.Collections;

public class RotationHautBas : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotate = new Vector3(1, 0, 0);

        //Rotation Haut
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localEulerAngles.x <90)
                transform.Rotate( rotate,1f,Space.Self);
        }
        //Rotation Bas
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.localEulerAngles.x <= 90 && transform.localEulerAngles.x > 1 )
                transform.Rotate( -rotate, 1f,Space.Self);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GameObject.Find("PivotCanon").transform.position, GameObject.Find("PivotCanon").transform.position - GameObject.Find("PivotCanon").transform.forward*20);
    }
}
