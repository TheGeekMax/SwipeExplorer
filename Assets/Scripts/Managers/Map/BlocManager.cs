using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocManager : MonoBehaviour{
    public List<TilePair> tilePairs;
    public string path = "Tiles/";
    public bool showTileList = false;
    public static BlocManager instance;
    
    //for tile entity and tile purpose
    Dictionary<string, Type> tileEntityIdToTypeMap;
    Dictionary<string, Type> tileIdToTypeMap;
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        tileEntityIdToTypeMap = new Dictionary<string, Type>();
        tileIdToTypeMap = new Dictionary<string, Type>();
        
        //initialise tile
        foreach(Type tile in FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(TileBloc))){
            //instanciate tile and print its name
            TileBloc tileInstance = (TileBloc)Activator.CreateInstance(tile,new Vector2Int(0,0));
            tileIdToTypeMap.Add(tileInstance.GetId(), tile);
        }
        
        //initialise tile entity
        foreach(Type tileEntity in FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(TileBlocEntity))){
            //instanciate tile entity and print its name
            TileBlocEntity tileEntityInstance = (TileBlocEntity)Activator.CreateInstance(tileEntity,new Vector2Int(0,0));
            tileEntityIdToTypeMap.Add(tileEntityInstance.GetId(), tileEntity);
        }
    }

    public TileBase GetTile(string tileName){
        foreach(TilePair tilePair in tilePairs){
            if(tilePair.name == tileName){
                return tilePair.tile;
            }
        }
        return null;
    }
    
    //pour la recherche de tile et tile entity
    private IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType){
        return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
    }
    
    public TileBlocConstructor GetTileType(string tileName){
        return new TileBlocConstructor(tileIdToTypeMap[tileName]);
    }
    
    public TileBlocConstructor GetTileEntityType(string tileEntityId){
        return new TileBlocConstructor(tileEntityIdToTypeMap[tileEntityId]);
    }
    
}
