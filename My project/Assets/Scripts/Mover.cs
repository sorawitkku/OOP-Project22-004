using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{   
    private Animator anim;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.5f;


    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset moveDelta
        moveDelta = input;

        //Swap sprite direction, whether you're going left or right
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
            anim.SetBool("Run", true);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Run", true);
        }
        else 
        {
            anim.SetBool("Run", false);
        }

        //Add
        moveDelta += pushDirection;

        //reduce the push
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //make sure we can move in this direction, by casting a box there first, if the box return null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make thing move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make thing move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
