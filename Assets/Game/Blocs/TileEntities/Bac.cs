using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bac : TileBlocEntity{
    string signal;
    
    private bool used = false;
    
    public Bac(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Bac_off");
        this.position = pos;
        this.isWalkable = false;
    }

    public override void OnInteract(){
        this.TileSprite = BlocManager.instance.GetTile("Bac_on");
        SignalManager.instance.SendSignal(signal);
        used = true;
        MapManager.instance.ForceInteract(this.position + new Vector2Int(0, 1));
    }
    
    public override bool IsInteractable(){
        return !used;
    }
    
    public override string GetId(){
        return "bac";
    }
    
    public override void SetupSignal(string prefix){
        signal = prefix + "_s1";
    }
}
