using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public abstract class TileBlocEntity{
    public TileBase TileSprite { get; protected set; }
    protected bool isWalkable = true;
    protected bool isInteractable = false;
    protected Vector2Int position;

    public Vector2Int GetPosition(){
        return position;
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
    
    public virtual bool IsWalkable(){
        return isWalkable;
    }

    public virtual bool IsInteractable(){
        return isInteractable;
    }

    public virtual void SetupSignal(string prefix){
        //do nothing
    }

    protected void RemoveSelf(){
        MapManager.instance.RemoveTileEntity(position);
    } 
    
    public abstract string GetId();

}
