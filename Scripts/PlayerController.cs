using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Singleton mode
    public static PlayerController instance;

    private Rigidbody2D rb;

    private float moveH;
    private float moveV;

    [SerializeField] private float moveSpeed = 5f;

    public string scenePassword;//切换场景的密码

    //temp
    private Vector2 temp1;

    private void Awake()
    {
        //Singleton mode
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        Move(moveH,moveV);
    }

    public void Move(float moveH,float moveV)
    {
        temp1.Set(moveH,moveV);
        rb.velocity = temp1;
    }

}
