using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float walkSpeed = 5f;

    public float moveH;
    public float moveV;

    public float healthPoint = 10f;

    //temp
    public Vector2 moveDir;

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * walkSpeed;
        moveV = Input.GetAxisRaw("Vertical") * walkSpeed;

        moveDir.Set(moveH, moveV);

        if (healthPoint < 1)
        {
            Debug.Log("蔡!");
        }
    }

    private void FixedUpdate()
    {
        Walk(moveDir);
    }

    private void Walk(Vector2 vec)
    {
        rb.velocity = vec;
    }

}
