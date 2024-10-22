using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTask_Wait : BTNode
{
    private float waitTime;
    float timeCount;
    public BTTask_Wait(float waitTime){
        this.waitTime=waitTime;
    }
    protected override NodeResult Excute()
    {
        timeCount=0f;
        if(timeCount>= waitTime){
            return NodeResult.Succes;
        }
        return NodeResult.Processing;
    }
    protected override NodeResult Update()
    {
        timeCount+= Time.deltaTime;
        if(timeCount >= waitTime){
            return NodeResult.Succes;
        }
        return NodeResult.Processing;
    }
    void Start()
    {
        
    }
}
