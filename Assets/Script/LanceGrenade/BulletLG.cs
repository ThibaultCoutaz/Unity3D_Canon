using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletLG : MonoBehaviour
{

    public GameObject ExitBullet;
    public GameObject Plane;
    public ParticleSystem p;
    public ParticleSystem p2;
    int nbBounce = 3;
    public float Rexplosion = 2f;
    public AudioClip explosion;

    void start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 16 && transform.position.z > 16 && transform.position.x < -16 && transform.position.z < -16) //To check if the bullet is in of the Map
        {
            ExitBullet.GetComponent<ShootLG>().DisableBullet(this.gameObject);
            nbBounce = 3;
        }

        if (nbBounce == 0)
        {
            ExitBullet.GetComponent<ShootLG>().DisableBullet(this.gameObject);
            nbBounce = 3;
            ExplosionDmg();
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Plane")
        {
            nbBounce--;
        }

        List<GameObject> cible = Plane.GetComponent<GamePlay>().TargetActive;

        if (cible.Count != 0)
            for (int i = 0; i < cible.Count; i++)
            {
                if (col.gameObject.name == cible[i].name)
                {
                    ExitBullet.GetComponent<ShootLG>().DisableBullet(this.gameObject);
                    if (cible[i].GetComponent<BehaviourTarget>().shield == true)
                    {
                        cible[i].GetComponent<BehaviourTarget>().shield = false;
                    }
                    else
                    {
                        cible[i].GetComponent<BehaviourTarget>().Life--;
                        if (cible[i].GetComponent<BehaviourTarget>().Life == 0)
                        {
                            //Control Sound
                            Camera.main.GetComponent<AudioSource>().PlayOneShot(explosion);
                            //Control Particule
                            ParticleSystem p = (Instantiate(cible[i].GetComponent<BehaviourTarget>().explosion.gameObject, cible[i].transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleSystem>();
                            p.Play();
                            Plane.GetComponent<GamePlay>().DisableTarget(cible[i], true);
                            Destroy(p, 0.5f);
                        }
                    }
                    
                }
            }
    }

    void ExplosionDmg()
    {
        List<GameObject> cible = Plane.GetComponent<GamePlay>().TargetActive;

        if (cible.Count != 0)
            for (int i = 0; i < cible.Count; i++)
            {
                if (distanceVector(cible[i].transform.position, transform.position) < Rexplosion)
                {
                    cible[i].GetComponent<BehaviourTarget>().Life-=4;
                    if (cible[i].GetComponent<BehaviourTarget>().Life < 1)
                    {
                        ParticleSystem p = (Instantiate(cible[i].GetComponent<BehaviourTarget>().explosion.gameObject, cible[i].transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleSystem>();
                        p.Play();
                        Plane.GetComponent<GamePlay>().DisableTarget(cible[i], true);
                        Destroy(p, 0.5f);
                    }
                }
            }
    }

    float distanceVector(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y) + (b.z - a.z) * (b.z - a.z));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Rexplosion);
    }
}
