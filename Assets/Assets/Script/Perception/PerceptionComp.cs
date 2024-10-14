using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionComp : MonoBehaviour
{
    [SerializeField] SenseComp[] senseComps;
    private LinkedList<PerceptionStumuli> currentlyPercepStimulis=new LinkedList<PerceptionStumuli>();
    PerceptionStumuli targetStimuli;
    public event EventHandler <TargetStimuli>  OnPerceptionTargetChanged;

    public class TargetStimuli: EventArgs{
        public GameObject stimuli;
        public bool sensed; 
    }
    private void Start()
    {
        foreach(SenseComp senseComp in senseComps){
            senseComp.UpdatePerception += SenseUpdate;
        }
    }

    private void SenseUpdate(object sender, SenseComp.OnPerceptionUpdate e)
    {
        var node=currentlyPercepStimulis.Find(e.stumuli);
        if(e.successfullySense){
            if(node != null){
                currentlyPercepStimulis.AddAfter(node,e.stumuli);
            }
            else {
                currentlyPercepStimulis.AddLast(e.stumuli);
            }
        }
        else {
            currentlyPercepStimulis.Remove(node);
        }
        if(currentlyPercepStimulis.Count !=0){
            PerceptionStumuli higestperceptionStumuli=currentlyPercepStimulis.First.Value;
            if(targetStimuli ==null || targetStimuli != higestperceptionStumuli){
                targetStimuli=higestperceptionStumuli;
                OnPerceptionTargetChanged?.Invoke(this, new TargetStimuli{
                    stimuli=targetStimuli.gameObject,
                    sensed=true
                });
            }
        }
        else {
            if(targetStimuli !=null){
                targetStimuli=null;
                OnPerceptionTargetChanged?.Invoke(this, new TargetStimuli{
                    stimuli=null,
                    sensed=false
                });
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
