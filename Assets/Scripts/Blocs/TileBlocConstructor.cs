
using System;
using UnityEngine;

public class TileBlocConstructor{
    private Type tileType;
    
    public TileBlocConstructor(Type tileType){
        this.tileType = tileType;
    }
    
    public TileBloc CreateTile(Vector2Int position){
        return (TileBloc)Activator.CreateInstance(tileType, position);
    }
    
    public TileBlocEntity CreateTileEntity(Vector2Int position){
        return (TileBlocEntity)Activator.CreateInstance(tileType, position);
    }
}