using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreHit : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                if (other.GetComponent<PlayerController>().currentState != PlayerState.stagger)
                {
                    hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerController>().Knock(knockTime, damage);
                }
            }
        }
    }
}
