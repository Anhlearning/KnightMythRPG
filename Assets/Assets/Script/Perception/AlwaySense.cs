using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaySense : SenseComp
{
    [SerializeField] private float distance=2f;
    protected override bool IsStumuliSensable(PerceptionStumuli stumuli)
    {
        if(Vector2.Distance(gameObject.transform.position,stumuli.transform.position)<=distance){
            return true;
        }
        return false;
    }

    protected override void OnDraw()
    {
        base.OnDraw();
        Gizmos.DrawWireSphere(transform.position,distance);
    }
}
