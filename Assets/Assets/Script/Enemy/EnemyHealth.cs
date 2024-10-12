using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth=10f;
    [SerializeField] private float knockBackTrust=5f;
    private Animator animator;
    private KnockBack knockBack;
    
    private float currentHealth;
    private Flash flash;
    void Awake()
    {   
        flash=GetComponent<Flash>();
        currentHealth=maxHealth;
        knockBack=GetComponent<KnockBack>();
        animator=GetComponent<Animator>();
    }

    public void TakeDamage(float damage){
        currentHealth-=damage;
        knockBack.GetKnockBack(Player.Instance.transform,knockBackTrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(checkDetecDeathRoutine());
    }
    private IEnumerator checkDetecDeathRoutine(){
        yield return new WaitForSeconds(flash.getRestoreMatTime());
        DetectDeath();
    }
    public void DetectDeath(){
        if(currentHealth <= 0){
            animator.SetTrigger("isDeath");
        }
    }
    public void Detroyself(){
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
