using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Compositor
{
    protected override NodeResult Update()
    {
        NodeResult nodeResult= getChildCurrent().UpdateNode();
        if(nodeResult == NodeResult.Failure){
            return NodeResult.Failure;
        }
        if(nodeResult == NodeResult.Succes){
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
