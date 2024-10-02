using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private ParticleSystem ps;
    void Awake()
    {
        ps=GetComponent<ParticleSystem>();     
    }

    // Update is called once per frame
    private void Update()
    {
        if(ps && !ps.IsAlive()){
            Debug.Log("Destroy");
            DestroySelf();
        }
    }
    private void DestroySelf(){
        Destroy(gameObject);
    }
}
