using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{

    private Animator anim;
    public BoxCollider2D physicsCollider;
    public LootTable thisLoot;
    private bool isSmashed = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        physicsCollider.enabled = true;
        isSmashed = false;
    }
    public void Smash()
    {
        anim.SetBool("smash", true);
        physicsCollider.enabled = false;
        if (!isSmashed)
        {
            isSmashed = true;
            MakeLoot();
        }
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
