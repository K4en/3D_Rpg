using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    //Components
    Animator animator;
    Rigidbody myRigidbody;

    //Variables
    float moveSpeed;

    //Conditionals
    bool walkForward;
    bool walkBackward;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        //Components
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();

        //Variables
        moveSpeed = 3.0f;

        //Conditionals
        walkForward = false;
        walkBackward = false;
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Forward movement
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            walkForward = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
            walkForward = false;
        }

        if (walkForward)
        {
            myRigidbody.velocity = transform.forward * moveSpeed;
        }

        //Backward movement
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackWalk", true);
            walkBackward = true;
        }
        else
        {
            animator.SetBool("isBackWalk", false);
            walkBackward = false;
        }

        if (walkBackward)
        {
            myRigidbody.velocity = -transform.forward * moveSpeed;
        }

        //Turn left and right move
        if (Input.GetKey(KeyCode.D)) transform.Rotate(0, 1, 0);
        if (Input.GetKey(KeyCode.A)) transform.Rotate(0, -1, 0);

        //Run
        if (Input.GetKey(KeyCode.LeftAlt) && walkForward)
        {
            animator.SetBool("isRunning", true);
            isRunning = true;
        }
        else
        {
            animator.SetBool("isRunning", false);
            isRunning = false;
        }

        if (isRunning) myRigidbody.velocity = transform.forward * 10.0f;


        //Jump states

        //Jump idle
        if (Input.GetKeyDown(KeyCode.Space) && !walkForward)  animator.SetTrigger("isJumpIdle");
                
        //Jump walk
        if (Input.GetKeyDown(KeyCode.Space) && walkForward) animator.SetTrigger("isJumpForward");

        ////Jump run
        //if (Input.GetKey(KeyCode.Space) && isRunning) {animator.SetBool("isJumpRun", true); } else { animator.SetBool("isJumpRun", false); }

    }
}
