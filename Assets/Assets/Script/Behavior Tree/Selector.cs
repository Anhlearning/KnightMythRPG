using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Compositor
{
    protected override NodeResult Update()
    {
        NodeResult nodeResult=getChildCurrent().UpdateNode();
        if(nodeResult == NodeResult.Succes){
            return NodeResult.Succes;
        }
        if(nodeResult == NodeResult.Failure){
            if(Next()){
                return NodeResult.Processing;
            }
            else {
                return NodeResult.Succes;
            }
        }
        return NodeResult.Processing;
    }
}
