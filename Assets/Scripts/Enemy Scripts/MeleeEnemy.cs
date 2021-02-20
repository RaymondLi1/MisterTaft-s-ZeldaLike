using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator animator;
    private Vector2 positionDif;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        positionDif = target.position - transform.position;
        positionDif.Normalize();
        CheckDistance();
    }

    public void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                myRigidbody.velocity = positionDif * moveSpeed;
                changeAnim(myRigidbody.velocity);
                ChangeState(EnemyState.walk);
                animator.SetBool("walking", true);
                animator.SetFloat("lastMoveX", myRigidbody.velocity.x);
                animator.SetFloat("lastMoveY", myRigidbody.velocity.y);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) <= attackRadius && Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            StartCoroutine(AttackCo());
        }

        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            animator.SetBool("walking", false);
            ChangeState(EnemyState.idle);
        }
    }

    public void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    public IEnumerator AttackCo()
    {
        if (currentState != EnemyState.stagger)
        {
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.attack;
            animator.SetBool("attacking", true);
            yield return new WaitForSeconds(0.5f);
            currentState = EnemyState.idle;
            animator.SetBool("attacking", false);
        }
    }
}
