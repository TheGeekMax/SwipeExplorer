using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : TileBlocEntity{
    public Key(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("Key");
        this.isWalkable = true;
        this.isInteractable = false;
        this.position = pos;
    }

    public override void OnWalk(){
        Item key = ItemSpawnerManager.instance.SpawnItem("key");
        PlayerInventoryManager.instance.AddItem(key);
        RemoveSelfDelayed(0.5f);
    }
}
