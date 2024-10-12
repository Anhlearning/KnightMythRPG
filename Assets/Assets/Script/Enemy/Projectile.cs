using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float moveSpeed;
    private float timeCountDownDestroy=5f;
    
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);
        // Destroyself();
    }

    public void UpdateSpeed(float moveSpeed){
        this.moveSpeed=moveSpeed;
    }
    public void Destroyself(){
        float time=0f;
        while(time <= timeCountDownDestroy){
            time+=Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
