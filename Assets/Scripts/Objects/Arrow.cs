using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;
    public float lifeTimeCounter = 5;
    public float magicCost;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (!timer.countTime)
            timer.BeginTimer();
        if (timer.timer >= lifeTimeCounter)
            Destroy(this.gameObject);
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
