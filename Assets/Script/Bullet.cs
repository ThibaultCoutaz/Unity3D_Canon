using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if(transform.position.x<16 && transform.position.z<16 && transform.position.x>-16 && transform.position.z > -16) //To check if the bullet is in of the Map
        {
            HitTarget();
        }
        else
        {
            GameObject.Find("ExitBullet").GetComponent<Shoot>().DisableBullet(this.gameObject);
        }
	}



    //To know if it hit a Target or not 
    void HitTarget()
    {
        List<GameObject> cible = GameObject.Find("Terrain").GetComponent<GamePlay>().TargetActive;
        float Rtarget = GameObject.Find("Terrain").GetComponent<GamePlay>().target.GetComponent<SphereCollider>().radius; //to take save the raduis of the Target

        if (cible.Count != 0)
            for (int i = 0; i < cible.Count; i++)
            {
                if (distanceVector(cible[i].transform.position, transform.position) <  Rtarget)
                {
                    GameObject.Find("ExitBullet").GetComponent<Shoot>().DisableBullet(this.gameObject);
                    cible[i].GetComponent<BehaviourTarget>().Life--;
                    if (cible[i].GetComponent<BehaviourTarget>().Life < 1)
                    {
                        print(cible[i].GetComponent<BehaviourTarget>().explosion);
                        (Instantiate(cible[i].GetComponent<BehaviourTarget>().explosion.gameObject, cible[i].transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleSystem>().Play();
                        GameObject.Find("Terrain").GetComponent<GamePlay>().DisableTarget(cible[i]);
                    }
                }
            }
        
    }


    float distanceVector(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y) + (b.z - a.z) * (b.z - a.z));
    }
}
