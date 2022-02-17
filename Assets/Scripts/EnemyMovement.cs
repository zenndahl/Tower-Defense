using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private enemy enemy;

    private void Start(){
        enemy = GetComponent<enemy>();

        target = waypoints.points[0];
    }

    // Update is called once per frame
    void Update(){
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);   

        if(Vector3.Distance(transform.position, target.position) <= 0.4f){
            GetNextWaypoint();
        }

        enemy.speed = enemy.baseSpeed;
    }

    void GetNextWaypoint(){

        if(wavepointIndex >= waypoints.points.Length - 1){
            Destroy(gameObject);
            wavespawner.enemiesAlive--;
            PlayerStats.Lives -= 1;
            return;
        }

        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }
}
