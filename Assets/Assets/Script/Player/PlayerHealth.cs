using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int maxHealth;
    [SerializeField]private float knockBackThrustAmount=10f;
    [SerializeField]private float damageRecoveryTime=1f;

    private KnockBack knockBack;
    private Flash flash;
    private int currentHeath;
    private bool canTakeDamage=true;
    private void Start() {
        currentHeath=maxHealth;
    }
    void Awake()
    {
        knockBack=GetComponent<KnockBack>();
        flash=GetComponent<Flash>();
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(!canTakeDamage){
            return;
        }
        EnemyAI enemyAI=other.transform.GetComponent<EnemyAI>();
        if(enemyAI && canTakeDamage){
            TakeDamage(3);
            knockBack.GetKnockBack(other.gameObject.transform,knockBackThrustAmount);
            StartCoroutine(flash.FlashRoutine());
        }
    }
    IEnumerator DamageTakeRoutine(){
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage=true;
    }
    public void TakeDamage(int damage){
        canTakeDamage=false;
        currentHeath-=damage;
        StartCoroutine(DamageTakeRoutine());
    }

}
