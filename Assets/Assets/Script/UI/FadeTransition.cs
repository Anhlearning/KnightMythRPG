using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : Singleton<FadeTransition>
{
    [SerializeField] private float fadeSpeed=1f;
    [SerializeField] private Image imageFade;

    IEnumerator fadeRoutine;

    public void FadeToBlack(){
        if(fadeRoutine!=null ){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine=FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }

    public void FadeToClear(){
        if(fadeRoutine !=null){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine=FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }



    IEnumerator FadeRoutine(float targetAlpha){
        while(!Mathf.Approximately(imageFade.color.a,targetAlpha)){
            float aplpha=Mathf.MoveTowards(imageFade.color.a,targetAlpha,fadeSpeed*Time.deltaTime);
            imageFade.color=new Color(imageFade.color.r,imageFade.color.g,imageFade.color.b,aplpha);
            yield return null;
        }
    }
}
