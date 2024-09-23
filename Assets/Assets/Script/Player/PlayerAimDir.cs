using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAimDir : MonoBehaviour
{
    private Transform amirTrans;
    float angelDir;
    void Start()
    {
        amirTrans=transform.Find("AimDir");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0f;
        Vector2 aimDir=(Vector2) ( mousePos-transform.position).normalized;
        float angel = Mathf.Atan2(aimDir.y,aimDir.x)*Mathf.Rad2Deg;
        angelDir=angel;
        amirTrans.eulerAngles=new Vector3(0,0,angel);
    }
    public float getAngel(){
        return angelDir;
    }
}
