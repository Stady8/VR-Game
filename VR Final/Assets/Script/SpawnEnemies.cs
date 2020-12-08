using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public enum SpawnState{SPAWNING,WAITING, COUNTING};


    [System.Serializable]
    public class Wave
    {
    public string name;
    public Transform enemy;
    public int count;
    public float rate;
    }
   

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
   // public Transform[] spawnPointsWave2;

  private List<Transform> possibleSpawns = new List<Transform> ();
 // private List<Transform> possibleSpawnsWave2 = new List<Transform> ();


    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

     void Start() {
         
         for (int i = 0; i < spawnPoints.Length; i++)
         {
             possibleSpawns.Add (spawnPoints [i]);
         }


// Wave2 add spawnPoints
/*
          for (int i = 0; i < spawnPointsWave2.Length; i++)
         {
             possibleSpawnsWave2.Add (spawnPointsWave2 [i]);
         }

        waveCountdown = timeBetweenWaves;

*/
     }

     void Update() {
                      
        if (state == SpawnState.WAITING){
            if(!EnemyIsAlive())
            {
                WaveCompleted();


            }
            else{
                return;
            }
       }

        if (waveCountdown <= 0){

            if(state != SpawnState.SPAWNING)
            {
                //spawn wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
            else{
   
                waveCountdown -= Time.deltaTime;
            }

        
    }

    void WaveCompleted(){
       
       possibleSpawns.Clear();

         for (int i = 0; i < spawnPoints.Length; i++)
         {
             possibleSpawns.Add (spawnPoints [i]);
         }
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1){
            //Comeplted all play last wave again
            nextWave = waves.Length - 1;
        }
        else {
        nextWave++;
        }
    }

    bool EnemyIsAlive(){

        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;

        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;

        }

        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave){

        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {  
             SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate);
            /*
             if(_wave.name == "1"){
                 SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds( 1f/_wave.rate);

                }
            if(_wave.name == "2"){
                 SpawnEnemyWave2(_wave.enemy);
                yield return new WaitForSeconds( 1f/_wave.rate);

                }
            */
            
        }

        state = SpawnState.WAITING;

        yield break;
      
    }


    void SpawnEnemy (Transform _enemy){

     //Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length) ];
    // Instantiate (_enemy, _sp.position, _sp.rotation);

   
    int spawnIndex = Random.Range (0, possibleSpawns.Count);  
       
    Instantiate (_enemy, possibleSpawns [spawnIndex].position, possibleSpawns [spawnIndex].rotation);
   
   
    possibleSpawns.RemoveAt(spawnIndex); 
    //print(spawnIndex);

}
/*
  void SpawnEnemyWave2 (Transform _enemy){

     //Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length) ];
    // Instantiate (_enemy, _sp.position, _sp.rotation);

   
    int spawnIndex = Random.Range (0, possibleSpawnsWave2.Count);  
       
    Instantiate (_enemy, possibleSpawnsWave2 [spawnIndex].position, possibleSpawnsWave2 [spawnIndex].rotation);
   
   
    possibleSpawnsWave2.RemoveAt(spawnIndex); 

}
*/

}
