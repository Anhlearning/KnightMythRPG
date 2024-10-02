using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float offSetParallax=-0.15f;
    Vector2 startPos;
    Camera cam;
    void Awake()
    {
        cam=Camera.main;
        startPos=transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        transform.position=startPos+Travel()*offSetParallax;    
    }
    
    private Vector2 Travel(){
        Vector2 travel = ((Vector2)cam.transform.position-startPos);
        return travel;
    }
}
