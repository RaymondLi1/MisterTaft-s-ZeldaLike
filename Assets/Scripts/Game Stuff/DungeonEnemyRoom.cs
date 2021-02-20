using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    private int enemyCount;
    public bool cleared = false;

    // Start is called before the first frame update
    public override void Start()
    {
        if (boundary.bounds.Contains(target.transform.position))
        {
            virtualCamera.SetActive(true);
            showText();
        }

        else
        {
            virtualCamera.SetActive(false);
            DeSpawnGameObjects();
        }

        enemyCount = enemies.Length;
        OpenDoors();
    }

    public void CheckEnemies()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            OpenDoors();
            cleared = true;
        }
    }

    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
        enemyCount = enemies.Length;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            for (int i = 0; i < doors.Length; i++)
            {
                ChangeActivation(doors[i], true);
            }
            showText();
            cleared = false;
            enemyCount = enemies.Length;
        }
    }
    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
            for (int i = 0; i < doors.Length; i++)
            {
                ChangeActivation(doors[i], false);
            }
        }
    }
}
