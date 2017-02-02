using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*By Björn Andersson*/
public class PlayerMovement : MonoBehaviour
{
    /*By Björn Andersson*/
    [SerializeField]
    float speed, jumpSpeed, rotateSpeed, gravity;

    CharacterController charCont;

    Vector3 moveDirection;

    void Start()
    {
        charCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (charCont.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        charCont.Move(moveDirection * Time.deltaTime);
    }
}