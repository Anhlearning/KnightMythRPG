using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAimDir : MonoBehaviour
{
    private Transform amirTrans;
    float angelDir;
    public static PlayerAimDir Instance{get;set;}
    private void Awake() {
        Instance=this;
    }
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
        Quaternion q=amirTrans.rotation;
        q.eulerAngles=new Vector3(0,0,angel);
        amirTrans.rotation=q;
    }
    public float getAngel(){
        return angelDir;
    }
}
