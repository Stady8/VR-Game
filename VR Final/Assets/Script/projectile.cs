using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Player player2;

    public float speed;

    private Transform player;
    private Vector3 target;


    public GameObject hand;



    void Start(){
         player = GameObject.FindGameObjectWithTag("Hand").transform;

         player2 = GameObject.FindObjectOfType<Player>();

        

       // Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z);
 
        // Aim bullet in player's direction.
       /// transform.rotation = Quaternion.LookRotation(playerPos);

          target = new Vector3(player.position.x, player.position.y,player.position.z);

        // GameObject bulletPrefabs = Instantiate(bullet, barrel.position, barrel.rotation);
       //  bulletPrefabs.GetComponent<Rigidbody>().velocity = speed * barrel.forward;


    }

    void Update(){

      
         transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if( transform.position == target)
          DestroyProjectile();
    }
     
   public void OnTriggerEnter (Collider col) 
        {
        
       if (col.gameObject.tag == "Hand")
        {

         player2.TakeDamage(10);
           //hand.TakeDamage(10);
          //player2.TakeDamage(10);
            DestroyProjectile();
    }
    }


     void DestroyProjectile(){
        
        Destroy(gameObject);

      }

}
