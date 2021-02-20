using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartReplenish : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if (playerHealth.RuntimeValue > playerHealth.initialValue)
                playerHealth.RuntimeValue = playerHealth.initialValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
