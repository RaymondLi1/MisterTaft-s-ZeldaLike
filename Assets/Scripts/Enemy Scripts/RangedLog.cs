using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedLog : Log
{
    [Header("Projectile Properties")]
    public GameObject projectile;
    public float fireDelay;
    public bool fire = true;
    public Timer timer;
    public float projectileSpeed;

    public override void OnEnable()
    {
        timer.countTime = false;
        timer.timer = 0f;
        fire = true;
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    public override void CheckDistance()
    {
        if (timer.activateTrigger)
            fire = true;
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (!timer.countTime)
                timer.LoopTimer(fireDelay);
            if ((currentState == EnemyState.idle || currentState == EnemyState.walk) && currentState != EnemyState.stagger)
            {
                if (fire)
                {
                    Vector3 tempVector = target.transform.position - transform.position;
                    tempVector.Normalize();
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<RockProjectile>().Launch(tempVector * projectileSpeed);
                    fire = false;
                }
                ChangeState(EnemyState.walk);
                animator.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if(timer.activateTrigger)
                timer.StopCounting();
            animator.SetBool("wakeUp", false);
            ChangeState(EnemyState.idle);
        }
    }


}
