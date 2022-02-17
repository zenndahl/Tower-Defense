using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private enemy enemy;

    [Header("General")]
    
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public float fireRate = 2f;
    public float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public int damageOverTime = 4;
    public float slowPercentage = 0.5f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10;

    public GameObject bulletPrefab;
    public GameObject fireBurstEffect;
    public Transform firePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;


        foreach (GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
             target = nearestEnemy.transform;
             enemy = nearestEnemy.GetComponent<enemy>();
        }
        else target = null;
    }

    // Update is called once per frame
    void Update()
    {
        //target dead or out of range
        if(target == null){
            if(useLaser){
                if(lineRenderer.enabled){
                    lineRenderer.enabled = false;
                    impactLight.enabled = false;
                    impactEffect.Stop();
                }
            }

            return;
        } 

        //find and lock on target
        LockOnTarget();

        //check if it is a laser beamer or projectile turrets
        if(useLaser){
            Laser();
        }
        else{
            //firing
            if(fireCountdown <= 0f){
                Shoot();
                fireCountdown = 1f /fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
       

        
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject fireEffect = (GameObject)Instantiate(fireBurstEffect, firePoint.position, firePoint.rotation);
        
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        Destroy(fireEffect, 0.15f);

        if(bullet != null){
            bullet.Seek(target);
        }
    }

    void Laser(){

        enemy.TakeDamage(damageOverTime * Time.deltaTime);
        enemy.Slow(slowPercentage);

        if(!lineRenderer.enabled){
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        } 

        //first position on turret fire point, second position on target, the beam will stretch between
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }

    void LockOnTarget(){
        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    //draw the range visualization on editor
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
