using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Vector2=UnityEngine.Vector2;
public class EnemyAI : MonoBehaviour
{
    private enum State{
        Idle,
        Roaming
    }
    private State state;
    private EnemyPatrolling enemyPatrolling;
    private Animator animator;
    [SerializeField]
    private List <GameObject> patrollingPosList;
    // Start is called before the first frame update
    void Awake()
    {
        enemyPatrolling=GetComponent<EnemyPatrolling>();
        animator=GetComponent<Animator>();
        state=State.Roaming;
    }
    private void Start() {
        StartCoroutine(RoamingCroutine());
    }
    private void Update() {
    }

    private IEnumerator RoamingCroutine(){
        while(state==State.Roaming){
            animator.SetBool("isWalking",true);
            UnityEngine.Vector2 roamingPos=GetRoamingPos();
            enemyPatrolling.MovePatrollingPos(roamingPos);
            yield return new WaitForSeconds(2f);
            animator.SetBool("isWalking",false);
            yield return new WaitForSeconds(2f);
        }
    }
    private UnityEngine.Vector2 GetRoamingPos(){
        int idxRandom=UnityEngine.Random.Range(0,patrollingPosList.Count);
        return  patrollingPosList[idxRandom].transform.position;
    }
   
}
