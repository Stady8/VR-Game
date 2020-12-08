using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

        public Text score;
        public Text gameOverScore;
        public Text highScore;

        int currentScore = 0;

        public GameObject gameOverUI;



        
   // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("GameOver") == 1){
            gameOverScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();;
            gameOverUI.SetActive (true);
           
        }else{
            gameOverUI.SetActive (false);
        }
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        score.text = currentScore.ToString();

    }


    public void updateScore(int Number){

        currentScore += Number;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        score.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("HighScore", 0)){
            
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore.text = currentScore.ToString();
        }


    }

}
