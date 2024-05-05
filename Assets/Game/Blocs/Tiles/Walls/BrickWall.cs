using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWall : TileBloc{
    public BrickWall(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("BricksWall");
        this.isWalkable = false;
        this.position = pos;
    }
}
