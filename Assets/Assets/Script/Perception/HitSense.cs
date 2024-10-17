using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSense : SenseComp
{
    [SerializeField] private float memoryDamage;
    [SerializeField] private EnemyHealth enemyHealth;
    Dictionary<PerceptionStumuli,Coroutine>HitMemory= new Dictionary<PerceptionStumuli, Coroutine>();
    protected override global::System.Boolean IsStumuliSensable(PerceptionStumuli stumuli)
    {
        return HitMemory.ContainsKey(stumuli);
    }
    private void Start() {
        enemyHealth.EnemyTakeDamage += HitSense_TakeDamage;
    }

    private void HitSense_TakeDamage(object sender, EnemyHealth.Instagitor e)
    {
        PerceptionStumuli stumuli = e.whoDamage.GetComponent<PerceptionStumuli>();
        if(stumuli !=null){
            Coroutine newForgettingCroutine=StartCoroutine(MemoryCroutine(stumuli));
            Debug.Log("Player Damage");
            if(HitMemory.TryGetValue(stumuli,out Coroutine hitCroutine)){
                StopCoroutine(hitCroutine);
                HitMemory[stumuli]=newForgettingCroutine;
            }
            else {
                HitMemory.Add(stumuli,newForgettingCroutine);
            }
        }
    }
    IEnumerator MemoryCroutine(PerceptionStumuli stumuli){
        yield return new WaitForSeconds(memoryDamage);
        Debug.Log("Lost Player Damage");
        HitMemory.Remove(stumuli);
    }
}
