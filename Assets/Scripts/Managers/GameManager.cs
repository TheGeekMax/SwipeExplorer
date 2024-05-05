using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    void Start(){
        //initialise diferents managers
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;

        //Map
        BlocManager.instance.initialise();
        MapManager.instance.initialise();
        CameraManager.instance.initialise();

        //Player
        PlayerManager.instance.initialise();
        PlayerMovementManager.instance.initialise();
        PlayerInteractionManager.instance.initialise();
        TouchManager.instance.initialise();

        //Sprites
        SpriteManager.instance.initialise();

        //item
        ItemIdManager.instance.initialise();
        ItemSpawnerManager.instance.initialise();


        PlayerInventoryManager.instance.initialise();


        //UI
        InventoryUIManager.instance.initialise();

    }
}
