using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    private Vector2 patrollingPostition;
    [SerializeField]
    private float speed=15f;
    private KnockBack knockBack;
    private Rigidbody2D rb;
    private void Awake() {
        knockBack=GetComponent<KnockBack>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(knockBack.GettingKnockBack){
            return;
        }
        if(patrollingPostition==null){
            return;
        }
        transform.position=Vector2.MoveTowards(transform.position,patrollingPostition,speed*Time.deltaTime);
    }

    public void MovePatrollingPos(Vector2 patrollingPos){
        patrollingPostition=patrollingPos;
    }
    
}
