using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorCollision : MonoBehaviour
{
    public Door myDoor;
    public DungeonEnemyRoom myRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!myRoom.cleared)
            myDoor.Close();
    }
}
