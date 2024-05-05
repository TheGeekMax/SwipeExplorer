using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBackground : TileBloc{
    public SandBackground(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("SandPath");
        this.isWalkable = true;
        this.position = pos;
    }
}
