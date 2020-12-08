using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{

 public Text HealthNum;

    void Start()
    {
    
    }

    void Update()
    {
   
    }

    

      void OnTriggerEnter (Collider col) 
        {
          if (col.CompareTag("Hand") || col.CompareTag("Hand2"))
          {
                SceneManager.LoadScene (sceneName:"GameScene");
           
          }

 
        }
}
