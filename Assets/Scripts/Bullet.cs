using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 5;
    
     

    public void Seek(Transform _target){
        target = _target;
    }

    // Update is called once per frame
    void Update(){

        //if target is lost
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distancePerFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget(){
        GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);

        if(explosionRadius > 0f){
            Explode();
        }
        else{
            Damage(target);
        }

        
        Destroy(effectInstance, 2f);
        //Destroy(gameObject);
        Destroy(gameObject);
    }

    void Damage(Transform enemy){

        enemy e = enemy.GetComponent<enemy>();

        if(e != null){
            e.TakeDamage(damage);
        }        
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, 1<<8);

        foreach (Collider collider in colliders){
            Debug.Log(collider);
            //if(collider.tag == "Enemy"){
                Damage(collider.transform);
            //}
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
