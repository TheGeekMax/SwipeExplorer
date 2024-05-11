using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : TileBloc{
    public BrickWall(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("BricksWall");
        this.IsWalkable = false;
        
        //pos
        this.position = pos;
    }
    
    public override string GetId(){
        return "brickwall";
    }
}
