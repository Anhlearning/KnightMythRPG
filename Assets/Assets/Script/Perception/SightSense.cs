using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using Vector2 = UnityEngine.Vector2;
public class SightSense : SenseComp
{
    [SerializeField]private float sightDistance=5f;
    [SerializeField]private float sighthalfAngel=5f;
    protected override bool IsStumuliSensable(PerceptionStumuli stumuli)
    {
        if(Vector2.Distance(stumuli.transform.position,transform.position)> sightDistance){
            return false;
        }
        Vector2 rightDir=transform.right;
        Vector2 stimuliDir=(stumuli.transform.position-transform.position).normalized;
        if(Vector2.Angle(rightDir,stimuliDir)>sighthalfAngel){
            return false;
        }
        if(Physics.Raycast(transform.position,stumuli.transform.position,out RaycastHit hitInfo,sightDistance)){
            if(hitInfo.transform.gameObject!=transform.gameObject){
                return false;
            }
        }
        return true;
    }
    protected override void OnDraw()
    {
        base.OnDraw();
        Gizmos.DrawWireSphere(transform.position,sightDistance);
        Vector2 rightHalfAngle=UnityEngine.Quaternion.AngleAxis(sighthalfAngel,UnityEngine.Vector3.forward)* (UnityEngine.Vector3)transform.right;
        Vector2 leftHalfAngle=UnityEngine.Quaternion.AngleAxis(-sighthalfAngel,UnityEngine.Vector3.forward)* (UnityEngine.Vector3)transform.right;
        Gizmos.DrawLine(transform.position,(Vector2)transform.position+rightHalfAngle*sightDistance);
        Gizmos.DrawLine(transform.position,(Vector2)transform.position+leftHalfAngle*sightDistance);
    }
}
