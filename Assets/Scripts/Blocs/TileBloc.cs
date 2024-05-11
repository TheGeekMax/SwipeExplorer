using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class TileBloc{
    public TileBase TileSprite { get; protected set; }
    public  bool IsWalkable{ get; protected set; }
    public int Id { get; protected set; }
    
    protected Vector2Int position;
    

    public Vector2Int GetPosition(){
        return position;
    }
    
    public abstract string GetId();

}
