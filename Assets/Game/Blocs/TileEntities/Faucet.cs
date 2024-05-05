using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : TileBlocEntity{
    public Faucet(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("Faucet_off");
        this.isWalkable = false;
        this.position = pos;
        this.isInteractable = false;
    }

    public override void OnInteract(){
        this.tile = BlocManager.instance.GetTile("Faucet_on");
    }
}
