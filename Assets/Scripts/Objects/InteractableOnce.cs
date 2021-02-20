using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableOnce : MonoBehaviour
{
    public bool playerInRange = false;
    public bool triggered = false;
    public Signal contextClue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !triggered)
        {
            contextClue.Raise();
            playerInRange = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !triggered)
        {
            contextClue.Raise();
            playerInRange = false;
        }
    }

    public void trigger()
    {
        triggered = true;
        contextClue.Raise();
        playerInRange = false;
    }

    public void triggerItem()
    {
        triggered = true;
        contextClue.Raise();
    }

    public void triggerSwitchDoor()
    {
        triggered = true;
        playerInRange = false;
    }

    public void triggerEnemyDoor()
    {
        triggered = true;
        if (playerInRange)
            contextClue.Raise();
        playerInRange = false;
    }
}
