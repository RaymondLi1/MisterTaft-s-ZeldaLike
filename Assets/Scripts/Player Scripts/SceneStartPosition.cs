using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartPosition : MonoBehaviour
{
    [Header("Game Objects' Starting Positions")]
    public VectorValue playerStorage;

    [Header("Default starting positions")]
    public Vector2 sampleSceneHouse;
    public Vector2 sampleSceneDungeon;
    public Vector2 houseInterior;
    public Vector2 dungeon;
    public StringValue lastScene;

    [Header("Player's starting direction to face")]
    public StartDirection startDirection;

    public void movePlayer()
    {
        switch (this.gameObject.scene.name)
        {
            case "SampleScene":

                if (lastScene.element == "Dungeon")
                {
                    playerStorage.defaultValue = sampleSceneDungeon;
                    playerStorage.initialValue = sampleSceneDungeon;
                    startDirection.startX = 0;
                    startDirection.startY = -1;
                    lastScene.element = "SampleScene";
                }
                else 
                {
                    playerStorage.defaultValue = sampleSceneHouse;
                    playerStorage.initialValue = sampleSceneHouse;
                    startDirection.startX = 0;
                    startDirection.startY = -1;
                    lastScene.element = "SampleScene";
                }


                break;

            case "HouseInterior":
                playerStorage.defaultValue = houseInterior;
                playerStorage.initialValue = houseInterior;
                startDirection.startX = 0;
                startDirection.startY = 1;
                lastScene.element = "HouseInterior";
                break;

            case "Dungeon":
                playerStorage.defaultValue = dungeon;
                playerStorage.initialValue = dungeon;
                startDirection.startX = 0;
                startDirection.startY = 1;
                lastScene.element = "Dungeon";
                break;

            case "StartMenu":
                lastScene.element = "SampleScene";
                break;

            default:
                break;
        }
    }
}
