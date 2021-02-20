using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp
{
    public Inventory playerInventory;
    public float magicValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.currentMagic += magicValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
