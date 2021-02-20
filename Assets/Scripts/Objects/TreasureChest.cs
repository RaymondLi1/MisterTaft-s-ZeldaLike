using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteractableOnce
{
    [Header("Contents")]
    public BoolValue storedOpen;
    public Item contents;
    public Inventory playerInventory;

    [Header("Signals and Dialogue")]
    public Signal raiseItem;
    public GameObject dialogueBox;
    public Text dialogueText;

    [Header("Animation")]
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        triggered = storedOpen.RunTimeValue;
        if (triggered)
        {
            animator.Play("treasureOpen", 0, 1.0f);
            animator.SetBool("Opened", true);
        }
        
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!triggered)
                OpenChest();
            else
                ChestIsOpened();
        }
    }

    public void OpenChest()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        animator.SetBool("Opened", true);
        triggerItem();
        storedOpen.RunTimeValue = triggered;
    }

    public void ChestIsOpened()
    {
        dialogueBox.SetActive(false);
        playerInRange = false;
        raiseItem.Raise();
    }
}