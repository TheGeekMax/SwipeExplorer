using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : TileBlocEntity{

    string signal;
    
    public GroundButton(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("GroundButton");
        this.isWalkable = true;
        this.isInteractable = false;
        this.position = pos;
    }

    public override void OnWalk(){
        SignalManager.instance.SendSignal(signal);
        RemoveSelfDelayed(0.5f);
    }
    
    public override string GetId(){
        return "ground_button";
    }
    
    public override void SetupSignal(string prefix){
        signal = prefix + "_s2";
    }
}
