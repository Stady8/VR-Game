using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      public float speed;
    public float stoppingDistance;
    public float retreaDistance;
    
    private float timeBtwShots;
    public float startTimeBtwShots = 4;

    public Transform barrel;

    private Transform player;
    public GameObject projectile;
    private Vector3 target;
    
    //public GameObject Enemys;
    public float bulletSpeed = 4;



    // Start is called before the first frame update
    void Start()
    {
     
        timeBtwShots = startTimeBtwShots;

    

    }

    // Update is called once per frame
    void Update()
    {
           player = GameObject.FindGameObjectWithTag("Hand").transform;
           target = new Vector3(player.position.x, player.position.y ,player.position.z);
        /*
        if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
             transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector3.Distance(transform.position, player.position) > stoppingDistance && Vector3.Distance(transform.position, player.position) > retreaDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) > retreaDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
           */ 
  
        //transform.LookAt(player.transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
       // transform.position += transform.forward * 1f * Time.deltaTime;

            
        if(timeBtwShots <= 0){
           // Instantiate(projectile, transform.position, Quaternion.identity);
          Instantiate(projectile, barrel.position, barrel.rotation);
            
            
             // transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

         //  GameObject enemyBulletPrefabs = Instantiate(projectile, barrel.position, barrel.rotation);
            //enemyBulletPrefabs.GetComponent<Rigidbody>().velocity = bulletSpeed * barrel.forward;
           //  projectile.velocity = (player.transform.position - projectile.transform.position).normalized * speed;

          //  Destroy(enemyBulletPrefabs, 9);


            timeBtwShots = Random.Range(3, 8);

          //  timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -= Time.deltaTime;
        }
    }
    
}
