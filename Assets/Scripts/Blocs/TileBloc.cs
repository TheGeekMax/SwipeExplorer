using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class TileBloc{
    protected TileBase tile;
    protected bool isWalkable;
    protected Vector2Int position;

    public TileBase GetTile(){
        return tile;
    }

    public bool IsWalkable(){
        return isWalkable;
    }

    public Vector2Int GetPosition(){
        return position;
    }
}
