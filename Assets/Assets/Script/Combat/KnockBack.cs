using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool GettingKnockBack{set;get;}
    [SerializeField]
    private float knockBackTime=2f;

    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    public void GetKnockBack(Transform damageSource,float knockBackTrust){
        GettingKnockBack=true;
        Vector2 dirKnockBack=(transform.position-damageSource.position).normalized*knockBackTrust*rb.mass;
        rb.AddForce(dirKnockBack,ForceMode2D.Impulse);
        StartCoroutine(KnockBackRoutine());
    }

    private IEnumerator KnockBackRoutine()
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity=Vector2.zero;
        GettingKnockBack=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
