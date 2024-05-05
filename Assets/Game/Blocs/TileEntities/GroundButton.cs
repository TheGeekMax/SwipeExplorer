using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : TileBlocEntity{

    string signal;
    public GroundButton(Vector2Int pos,string signal){
        this.tile = BlocManager.instance.GetTile("GroundButton");
        this.isWalkable = true;
        this.isInteractable = false;
        this.position = pos;
        this.signal = signal;
    }

    public override void OnWalk(){
        SignalManager.instance.SendSignal(signal);
        RemoveSelfDelayed(0.5f);
    }
}
