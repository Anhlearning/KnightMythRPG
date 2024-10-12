using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using Vector2 = UnityEngine.Vector2;
public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform butlletPrefabs;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int brustCount;
    [SerializeField] private int projectilePerBrust;
    [SerializeField] private float startingDistance=0.1f;
    [SerializeField][Range(0,360)] private float angleSpread;
    [SerializeField] private float timeCountDownPerBrust;
    [SerializeField] private float resetTime;
    private bool isShooting=false;
    float TimeCoundDownTest=1f;

    private void Start() {
        float timeTest=0f;
        while(timeTest<= TimeCoundDownTest){
            timeTest+=Time.deltaTime;
        }    
        Attack();
    }
    public void Attack(){
        if(!isShooting){
            Debug.Log("ATTACK"); 
            StartCoroutine(ShootingCroutine());
        }
    }
    IEnumerator ShootingCroutine(){
        isShooting=true;
        float startAngle,currentAngle,stepAngle;
        TargetConeOfInfluence(out startAngle,out currentAngle,out stepAngle);
        for(int i=0;i<brustCount;i++){
            for(int j=0;j<projectilePerBrust;j++){
                Vector2 spwanPos=FindBulletSpawnPos(currentAngle);
                Transform newBullet=Instantiate(butlletPrefabs,spwanPos,UnityEngine.Quaternion.identity);
                newBullet.transform.right=newBullet.transform.position-transform.position;
                if(newBullet.TryGetComponent(out Projectile projectile)){
                    projectile.UpdateSpeed(moveSpeed);
                }
                currentAngle+= stepAngle;
            }
            // currentAngle=startAngle;
            yield return new WaitForSeconds(timeCountDownPerBrust);
            TargetConeOfInfluence(out startAngle,out currentAngle,out stepAngle);
        }
        yield return new WaitForSeconds(resetTime);
        isShooting=false;
    }
    private void TargetConeOfInfluence(out float startAngle,out float currentAngle,out float stepAngle){
        Vector2 dirShoot=Player.Instance.transform.position - transform.position;
        float targetAngel=Mathf.Atan2(dirShoot.x,dirShoot.y)*Mathf.Rad2Deg;
        startAngle=targetAngel;
        currentAngle=targetAngel;
        float endAngle=targetAngel;
        float halfAngleSpread=0f;
        stepAngle=0f;
        if(angleSpread !=0){
            stepAngle=angleSpread/(projectilePerBrust-1);
            halfAngleSpread=angleSpread/2;
            startAngle=targetAngel-halfAngleSpread;
            endAngle=targetAngel+halfAngleSpread;
            currentAngle=startAngle;
        }
    }
    private Vector2 FindBulletSpawnPos(float angleCurrent){
        float x = transform.position.x +startingDistance*MathF.Cos(angleCurrent*Mathf.Deg2Rad);
        float y=transform.position.y+ startingDistance*Mathf.Sin(angleCurrent*Mathf.Deg2Rad);
        return new Vector2(x,y);
    }
}
