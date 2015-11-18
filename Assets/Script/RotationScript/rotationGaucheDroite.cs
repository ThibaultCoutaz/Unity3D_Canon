using UnityEngine;
using System.Collections;

public class rotationGaucheDroite : MonoBehaviour {

    public float turnSpeed = 50f;
    public string test = "Object : Base";


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

    //Pour les cacules au niveau de la physique
    //void FixedUpdate(){


    //}
}
