using UnityEngine;
using System.Collections;

public class RotationHautBas : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotate = new Vector3(1, 0, 0);
        //GameObject Base = GameObject.Find("Base");

        ////************Test d'exsistance**************//
        //if (Base != null)
        //    print("Exsiste");
        //else
        //    print("Fail");
        //*********************************************//

        //print(Base.GetComponent<rotationGaucheDroite>().test);


        //Rotation Haut
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localEulerAngles.x <90)
                transform.Rotate( rotate,1f,Space.Self);

            //print(transform.eulerAngles.x);
        }
        //Rotation Bas
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.localEulerAngles.x <= 90 && transform.localEulerAngles.x > 1 )
                transform.Rotate( -rotate, 1f,Space.Self);

            //print(transform.eulerAngles.x);
        }
    }
}
