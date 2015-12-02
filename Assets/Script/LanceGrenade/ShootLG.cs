using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootLG : MonoBehaviour {

    public GameObject bullet;
    public float Speed;
    bool Shootdone = true;
    Rigidbody rb;
    public List<GameObject> BulletActive = new List<GameObject>();
    public List<GameObject> BulletInActive = new List<GameObject>();
    public GameObject LanceGrenade;
    public GameObject Plane;

    // Update is called once per frame
    void Update()
    {

        if (LanceGrenade.GetComponent<DetectionLG>().detect == true)
        {
            if (Shootdone == true)
                StartCoroutine("Shooting");
        }

    }

    IEnumerator Shooting()
    {

        if (BulletInActive.Count == 0)
        {
            bullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<BulletLG>().ExitBullet = this.gameObject;
            bullet.GetComponent<BulletLG>().Plane = Plane;
            rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformVector(new Vector3(0, 1, 0)) * Speed;
            BulletActive.Add(bullet);
            Shootdone = false;
            yield return new WaitForSeconds(0.5f);
            Shootdone = true;
        }
        else
        {
            BulletInActive[0].transform.position = transform.position;
            BulletInActive[0].transform.rotation = transform.rotation;
            rb = BulletInActive[0].GetComponent<Rigidbody>();
            rb.velocity = transform.TransformVector(new Vector3(0, 1, 0)) * Speed;
            BulletInActive[0].SetActive(true);
            BulletActive.Add(BulletInActive[0]);
            BulletInActive.Remove(BulletInActive[0]);
            Shootdone = false;
            yield return new WaitForSeconds(0.5f);
            Shootdone = true;
        }
    }

    //To put a BulletInactive
    public void DisableBullet(GameObject destroyBullet)
    {
        destroyBullet.SetActive(false);
        BulletInActive.Add(destroyBullet);
        BulletActive.Remove(destroyBullet);
    }
}

