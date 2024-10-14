using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionStumuli : MonoBehaviour
{
    
    private void Start()
    {
        SenseComp.RegisterStimuli(this);
    }

    private void OnDestroy() {
        SenseComp.RemoveStimuli(this);
    }
}
