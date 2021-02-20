using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorType
{
    key, enemy, button, breakable
}

public class Door : InteractableOnce
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject dialogueBox;
    public Text dialogueText;
    public string message;
    public bool needText;
    private bool closeText;
    Coroutine lastRoutine = null;

    private void OnEnable()
    {
        if (this.thisDoorType == DoorType.enemy)
            triggered = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if(playerInventory.numberOfKeys>0)
                {
                    playerInventory.numberOfKeys--;
                    Open();
                }

            }
            else if(closeText)
            {
                dialogueBox.SetActive(false);
            }
        }
    }

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        if (needText)
            lastRoutine = StartCoroutine(showText());
        if (thisDoorType == DoorType.button)
            triggerSwitchDoor();
        else if (thisDoorType == DoorType.key)
            trigger();
        else if (thisDoorType == DoorType.enemy)
            triggerEnemyDoor();
    }

    public void Close()
    {
        doorSprite.enabled = true;
        open = false;
        physicsCollider.enabled = true;
    }

    private IEnumerator showText()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = message;
        yield return new WaitForSeconds(0.3f);
        closeText = true;
        yield return new WaitForSeconds(2f);
        dialogueBox.SetActive(false);
    }
}
