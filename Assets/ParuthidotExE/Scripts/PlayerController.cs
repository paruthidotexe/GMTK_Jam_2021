using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 moveDirInputAction = Vector2.zero;
    Vector3 moveDir = Vector3.zero;

    public GameObject playerPink; 

    void Start()
    {
        AudioMgr.Inst.OnPlaySFX(SFXValues.SFX_Click);
    }


    void Update()
    {
        
    }

    public void OnMoveInputAction(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("OnMoveInputAction : " + context.ReadValue<Vector2>());
            //Debug.Log(context.ReadValue<Vector3>());
            moveDirInputAction = context.ReadValue<Vector2>();
            moveDir.x = moveDirInputAction.x;
            moveDir.y = 0;
            moveDir.z = moveDirInputAction.y;
            OnMove(moveDir);
        }
    }

    public void OnMove(Vector3 direction)
    {
        Debug.Log("OnMove :" + direction);
        transform.position += direction;
        playerPink.transform.position += -direction;
    }
}
