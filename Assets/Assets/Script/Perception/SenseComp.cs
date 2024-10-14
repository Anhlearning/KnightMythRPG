using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SenseComp : MonoBehaviour
{
    private float timeForgetting=2f;
    static List<PerceptionStumuli> registerStumulis= new List<PerceptionStumuli>();
    List<PerceptionStumuli>currentStumulis = new List<PerceptionStumuli>();
    Dictionary<PerceptionStumuli,Coroutine>forgettingRoutines= new Dictionary<PerceptionStumuli, Coroutine>();
    public event EventHandler<OnPerceptionUpdate> UpdatePerception;
    public class OnPerceptionUpdate : EventArgs {
        public PerceptionStumuli stumuli;
        public bool successfullySense;
    }
    public static void RegisterStimuli(PerceptionStumuli perceptionStumuli){
        if(registerStumulis.Contains(perceptionStumuli)){
            return;
        }
        registerStumulis.Add(perceptionStumuli);
    }
    
    public static void RemoveStimuli(PerceptionStumuli perceptionStumuli){
        registerStumulis.Remove(perceptionStumuli);
    }

    protected abstract bool IsStumuliSensable(PerceptionStumuli stumuli);
    void Update()
    {
        foreach(var stumuli in registerStumulis){
            if(IsStumuliSensable(stumuli)){
                if(!currentStumulis.Contains(stumuli)){
                    currentStumulis.Add(stumuli);
                    if(forgettingRoutines.TryGetValue(stumuli,out Coroutine coroutine)){
                        StopCoroutine(coroutine);
                        forgettingRoutines.Remove(stumuli);
                    }
                    else {
                        UpdatePerception?.Invoke(this, new OnPerceptionUpdate {
                            stumuli=stumuli,
                            successfullySense=true
                        });
                        Debug.Log("Succes stumuli");
                    }
                }
            }
            else {
                if(currentStumulis.Contains(stumuli)){
                    currentStumulis.Remove(stumuli);
                    forgettingRoutines.Add(stumuli,StartCoroutine(ForgettingCroutine(stumuli)));
                }
            }
        }
    }
    IEnumerator ForgettingCroutine(PerceptionStumuli perceptionStumuli){
        yield return new WaitForSeconds(timeForgetting);
        Debug.Log("I lost track stumuli");
        forgettingRoutines.Remove(perceptionStumuli);
        UpdatePerception?.Invoke(this , new OnPerceptionUpdate{
            stumuli=perceptionStumuli,
            successfullySense=false
        });
    }
    protected virtual void OnDraw(){
        
    }
    private void OnDrawGizmos() {
        OnDraw();
    }
}
