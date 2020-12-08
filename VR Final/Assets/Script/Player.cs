using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Text HealthNum;

    public Image damageScreen;
    Color alphaColor;

bool isRegenHealth;

    int gameOver = 0;


    

    // Start is called before the first frame update
    void Start()
    
    {
       PlayerPrefs.SetInt("GameOver", 0);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        HealthNum.color = healthBar.fill.color;
        HealthNum.text = currentHealth.ToString();
        alphaColor = damageScreen.color;
       
    }

    // Update is called once per frame
    public void Update()
    {
        if(currentHealth != maxHealth && !isRegenHealth) 
         {
             StartCoroutine(RegainHealthOverTime());
         }
    }

    

    void OnTriggerEnter (Collider col) 
        {
          if (col.CompareTag("Bullet"))
          {
          
           TakeDamage(10);
           
          }

 
        }

    public void TakeDamage(int damge)
    {
        if(damge > currentHealth){
             GameOver();
        }

        currentHealth -= damge;

        if(currentHealth <= 0){
             GameOver();
        }

        alphaColor.a += .1f;
        damageScreen.color = alphaColor;

        healthBar.SetHealth(currentHealth);
        HealthNum.color = healthBar.fill.color;
        HealthNum.text = currentHealth.ToString();
    }
    

    private IEnumerator RegainHealthOverTime() 
     {
         isRegenHealth = true;
         while (currentHealth < maxHealth) 
         {
             Heal(5);
             yield return new WaitForSeconds (5);
         }
         isRegenHealth = false;
     }
 

    public void Heal(int heal){
            currentHealth += heal;
            alphaColor.a -= .1f;
            damageScreen.color = alphaColor;

        healthBar.SetHealth(currentHealth);
        HealthNum.color = healthBar.fill.color;
        HealthNum.text = currentHealth.ToString();
       
    }

    public void GameOver(){
        PlayerPrefs.SetInt("GameOver", 1);
             SceneManager.LoadScene (sceneName:"MainMenu");
    }
}
