using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocManager : MonoBehaviour{
    public List<TilePair> tilePairs;
    public string path = "Tiles/";
    public bool showTileList = false;
    public static BlocManager instance;
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
    }

    public TileBase GetTile(string tileName){
        foreach(TilePair tilePair in tilePairs){
            if(tilePair.name == tileName){
                return tilePair.tile;
            }
        }
        return null;
    }
}
