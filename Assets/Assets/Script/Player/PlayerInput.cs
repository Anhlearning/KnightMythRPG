using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController playerController;
    // Start is called before the first frame update
    private void Awake() {
        playerController= new PlayerController();
        playerController.Enable();
    }
    private void OnEnable() {
    }
    private void Start()
    {
        
    }
    public Vector2 GetMovementVectorNormolized(){
        Vector2 inputvector= playerController.Movement.Move.ReadValue<Vector2>();
        return inputvector.normalized;
    }
        
}
