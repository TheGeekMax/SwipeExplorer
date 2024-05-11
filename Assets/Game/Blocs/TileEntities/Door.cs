using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TileBlocEntity{
    public Door(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Door_closed");
        this.isInteractable = false;
        this.isWalkable = false;
        this.position = pos;
    }

    public override bool IsWalkable(){
        if(!this.isWalkable && PlayerInventoryManager.instance.HasItem("key")){
            this.isWalkable = true;
            this.TileSprite = BlocManager.instance.GetTile("Door_open");
            PlayerInventoryManager.instance.Consume("key");
            MapManager.instance.UpdateTile(this.position);
        }
        return this.isWalkable;
    }
    
    public override string GetId(){
        return "door";
    }
}
