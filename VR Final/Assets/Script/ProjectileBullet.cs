using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{


    public Score score;

    // Start is called before the first frame update
    void Start()
    {
       score = GameObject.FindObjectOfType<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter (Collider col) 
        {
          if (col.gameObject.tag == "Enemy")
          {
        
            Destroy(col.gameObject);
            score.updateScore(1);
                
          }
 
        }

}
