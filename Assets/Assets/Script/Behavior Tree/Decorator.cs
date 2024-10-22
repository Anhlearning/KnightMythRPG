using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : BTNode 
{
    BTNode child;

    public Decorator(BTNode child)
    {
        this.child=child;
    }
    protected BTNode GetChild(){
        return child;
    }
    public override BTNode Get()
    {
        return child.Get();
    }
    public override void SortPriority(ref int priorityRef)
    {
        base.SortPriority(ref priorityRef);
        child.SortPriority(ref priorityRef);
    }
}
