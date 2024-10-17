using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{   
    [SerializeField]
    private float damage=2f;
    private void OnTriggerEnter2D(Collider2D other) {
        // if(other.transform.GetComponent<EnemyHealth>()==null){
        //     return;
        // }
        EnemyHealth enemyHealth=other.GetComponent<EnemyHealth>();
        enemyHealth?.TakeDamage(damage,gameObject.GetComponentInParent<Player>().gameObject);
    }
}
