using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float walkSpeed = 5f;

    private float MoveH;
    private float MoveV;

    //tempVec
    private Vector2 temp1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveH = Input.GetAxisRaw("Horizontal") * walkSpeed;
        MoveV = Input.GetAxisRaw("Vertical") * walkSpeed;

        temp1.Set(MoveH,MoveV);

        Walk(temp1);
    }

    private void Walk(Vector2 vec)
    {
        rb.velocity = vec;
    }

}
