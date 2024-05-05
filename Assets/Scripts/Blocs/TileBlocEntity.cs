using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public abstract class TileBlocEntity{
    protected TileBase tile;
    protected bool isWalkable;
    protected Vector2Int position;
    protected bool isInteractable;

    public TileBase GetTile(){
        return tile;
    }

    public virtual bool IsWalkable(){
        return isWalkable;
    }

    public Vector2Int GetPosition(){
        return position;
    }

    public virtual bool IsInteractable(){
        return isInteractable;
    }

    public virtual void OnSignalRecieved(string signal){
        //do nothing
    }
    public virtual void OnWalk(){
        //do nothing
    }
    public virtual void OnInteract(){
        //do nothing
    }

    protected void RemoveSelfDelayed(float delay){
        //Invoke("RemoveSelf", delay);
        RemoveSelf();
    }

    protected void RemoveSelf(){
        MapManager.instance.RemoveTileEntity(position);
    }
}
