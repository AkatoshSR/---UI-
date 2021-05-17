using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wayPointOne;
    public Transform wayPointTwo;
    public GameObject bullet;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackRange;

    private Transform currentWayPoint;
    private SpriteRenderer sp;
    private Animator anim;

    private Transform attackTarget;


    private void Start()
    {
        currentWayPoint = wayPointOne;
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        attackTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, attackTarget.position) >= attackRange)
        {
            anim.SetBool("isAttack", false);
            Patrol();
        }
        else
        {
            anim.SetBool("isAttack", true);
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPointOne.position) <= 0.01f)
        {
            currentWayPoint = wayPointTwo;
            sp.flipX = true;
        }

        if (Vector2.Distance(transform.position, wayPointTwo.position) <= 0.01f)
        {
            currentWayPoint = wayPointOne;
            sp.flipX = false;
        }
    }

    public void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
