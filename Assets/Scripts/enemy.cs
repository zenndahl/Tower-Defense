using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy : MonoBehaviour{
    
    public float baseSpeed = 10f;
    public float startHealth = 10;

    [HideInInspector]
    public float speed = 20f;
    private float health;
    public int reward = 50;

    [Header("Unity")]
    public Image healthBar;

    private void Start() {
        speed = baseSpeed;
        health = startHealth;
    }

    private void Update() {
        
    }

    public void TakeDamage(float damage){

        health -= damage;
        healthBar.fillAmount = health/startHealth;

        //Debug.Log("Damage: " + damage);
        //Debug.Log("Health: " + health);

        if(health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        PlayerStats.Money += reward;

        wavespawner.enemiesAlive--;
    }

    public void Slow(float percentage){
        speed = baseSpeed * (1f - percentage);
    }
}
