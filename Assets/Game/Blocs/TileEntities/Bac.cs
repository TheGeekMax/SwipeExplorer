using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bac : TileBlocEntity{
    string signal;
    public Bac(Vector2Int pos, string signal){
        this.tile = BlocManager.instance.GetTile("Bac_off");
        this.isWalkable = false;
        this.position = pos;
        this.isInteractable = true;
        this.signal = signal;
    }

    public override void OnInteract(){
        this.tile = BlocManager.instance.GetTile("Bac_on");
        this.isInteractable = false;
        SignalManager.instance.SendSignal(signal);
        MapManager.instance.ForceInteract(this.position + new Vector2Int(0, 1));
    }
    
}
