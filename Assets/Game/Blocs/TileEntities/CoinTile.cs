using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTile : TileBlocEntity{
    public CoinTile(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Coin");
        this.isWalkable = true;
        this.isInteractable = false;
        this.position = pos;
    }

    public override void OnWalk(){
        Item key = ItemSpawnerManager.instance.SpawnItem("coin");
        PlayerInventoryManager.instance.AddItem(key);
        RemoveSelfDelayed(0.5f);
    }
    
    public override string GetId(){
        return "coin";
    }
}
