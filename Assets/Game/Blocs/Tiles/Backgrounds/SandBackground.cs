using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBackground : TileBloc{
    public SandBackground(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("SandPath");
        this.IsWalkable = true;
        
        //pos
        this.position = pos;
    }
    
    public override string GetId(){
        return "sand";
    }
}
