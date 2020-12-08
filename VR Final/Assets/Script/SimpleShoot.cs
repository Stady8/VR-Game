using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform barrel;
    //public GameObject Enemys;
    public float speed = 4;

    public void Fire(){
        GameObject bulletPrefabs = Instantiate(bullet, barrel.position, barrel.rotation);
        bulletPrefabs.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        Destroy(bulletPrefabs, 9);

     
    }

}
