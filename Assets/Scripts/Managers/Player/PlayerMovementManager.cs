using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour{
    public static PlayerMovementManager instance;
    private Player playerInstance;
    private MapManager mapManagerInstance;
    
    private Vector2 shakeTotalDirection = new Vector2(0, 0);

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        playerInstance = PlayerManager.instance.GetPlayer();
        mapManagerInstance = MapManager.instance;
    }

    //movement
    public void up(){
        Vector2Int gridPosition = playerInstance.GetGridPosition();
        //move player up until wall
        while(mapManagerInstance.IsWalkable(new Vector2Int(gridPosition.x , gridPosition.y + 1))){
            gridPosition.y++;
        }
        playerInstance.SetGridPosition(gridPosition);
        shakeTotalDirection += new Vector2(0, 1);
        Shake();
        PlayerInteractionManager.instance.updateInteractButton();
    }

    public void down(){
        Vector2Int gridPosition = playerInstance.GetGridPosition();
        //move player down until wall
        while(mapManagerInstance.IsWalkable(new Vector2Int(gridPosition.x , gridPosition.y - 1))){
            gridPosition.y--;
        }
        playerInstance.SetGridPosition(gridPosition);
        shakeTotalDirection += new Vector2(0, -1);
        Shake();
        PlayerInteractionManager.instance.updateInteractButton();
    }

    public void left(){
        Vector2Int gridPosition = playerInstance.GetGridPosition();
        //move player left until wall
        while(mapManagerInstance.IsWalkable(new Vector2Int(gridPosition.x - 1 , gridPosition.y))){
            gridPosition.x--;
        }
        playerInstance.SetGridPosition(gridPosition);
        shakeTotalDirection += new Vector2(-1, 0);
        Shake();
        PlayerInteractionManager.instance.updateInteractButton();
    }

    public void right(){
        Vector2Int gridPosition = playerInstance.GetGridPosition();
        //move player right until wall
        while(mapManagerInstance.IsWalkable(new Vector2Int(gridPosition.x + 1 , gridPosition.y))){
            gridPosition.x++;
        }
        playerInstance.SetGridPosition(gridPosition);
        shakeTotalDirection += new Vector2(1, 0);
        Shake();
        PlayerInteractionManager.instance.updateInteractButton();
    }

    public void Shake(){
        CameraManager.instance.Shake(shakeTotalDirection);
        shakeTotalDirection = new Vector2(0, 0);
    }

    public void forcePosition(Vector2Int gridPosition){
        playerInstance.SetGridPosition(gridPosition);
    }
}
