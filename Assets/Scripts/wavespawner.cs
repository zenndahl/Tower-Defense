using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public float btwTime = 5f;
    public Transform spawnPoint;
    //public float spawnDistance = 0.5f;

    public Text waveCountdownTimer;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update() {

        if(enemiesAlive > 0){
            return;
        }

        if(countdown <= 0f){
            StartCoroutine(spawnWave());
            countdown = btwTime;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);

        waveCountdownTimer.text = Mathf.Round(countdown).ToString();
    }


    IEnumerator spawnWave(){
        
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++){
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
        
    }

    void spawnEnemy(GameObject enemy){
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
