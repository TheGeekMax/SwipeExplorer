using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class MapManager : MonoBehaviour{
    public static MapManager instance;

    public Tilemap tileMapBloc;
    public Tilemap tileMapEntity;

    public int gridWidth = 3;
    public int gridHeight = 3;


    public TileBloc[,] mapBloc;
    public TileBlocEntity[,] mapEntity;


    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        generateMap();
    }

    private void generateMap(){
        //generate map
        
        /*
        TileBloc w = new BrickWall(new Vector2Int(0, 0));
        TileBloc i = new SandBackground(new Vector2Int(0, 0));

        TileBloc b = new Bush(new Vector2Int(0, 0));
        TileBloc g = new Grass(new Vector2Int(0, 0));
        TileBloc n = null;
        mapBloc = new TileBloc[,]{
        {w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w},
        {w, i, w, i, i, i, i, i, i, i, i, i, i, w, i, i, i, i, i, i, w},
        {w, i, w, i, w, w, i, w, i, w, w, w, i, w, i, w, w, i, w, i, w},
        {w, i, w, i, i, w, i, w, i, w, n, w, i, w, i, i, w, i, w, i, w},
        {w, i, w, w, i, w, i, w, i, w, n, w, i, w, w, i, w, i, w, i, w},
        {w, i, i, i, i, i, i, w, i, w, n, w, i, i, i, i, i, i, w, i, w},
        {w, i, w, i, w, w, i, w, i, w, n, w, i, w, i, w, w, i, w, i, w},
        {w, i, w, i, w, i, i, i, i, w, n, w, i, w, i, w, i, i, w, i, w},
        {w, i, i, i, w, w, w, w, i, w, n, w, i, i, i, w, w, i, w, i, w},
        {w, w, w, w, w, w, w, w, w, w, n, w, w, w, w, w, w, i, w, w, w},
        {n, n, n, n, n, n, n, n, n, n, n, n, n, n, n, n, w, i, w, n, n},
        {n, n, n, n, n, n, n, n, n, n, n, b, b, b, b, b, b, g, b, b, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, g, g, g, g, g, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, g, b, b, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, g, g, b, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, b, g, b, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, g, g, g, g, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, g, b, b, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, b, g, b, g, g, b, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, g, g, g, b, b, g, g, g, b},
        {n, n, n, n, n, n, n, n, n, n, n, b, b, b, b, b, b, b, b, b, b}

        };
        
        
        mapEntity = new TileBlocEntity[mapBloc.GetLength(0), mapBloc.GetLength(1)];
        mapEntity[9,8] = new Faucet(new Vector2Int(8, 9));
        mapEntity[8,8] = new Bac(new Vector2Int(8, 8),"s1");
        mapEntity[7,5] = new GroundButton(new Vector2Int(5,7),"s2");
        mapEntity[1,9] = new AndDoor(new Vector2Int(1,9),"s1","s2");
        mapEntity[8,19] = new Key(new Vector2Int(19,8));
        mapEntity[11,17] = new Door(new Vector2Int(17,11));
        */
        
        RoomGenerator room = new RoomGenerator(gridWidth, gridHeight);
        room.Generate();
        CellType[,] mapB = room.GetRoom();
        mapBloc = new TileBloc[mapB.GetLength(0), mapB.GetLength(1)];
        for(int i = 0; i < mapB.GetLength(0); i++){
            for(int j = 0; j < mapB.GetLength(1); j++){
                switch(mapB[i, j]){
                    case CellType.WALL:
                        mapBloc[i, j] = new BrickWall(new Vector2Int(j, i));
                        break;
                    case CellType.FLOOR:
                        mapBloc[i, j] = new SandBackground(new Vector2Int(j, i));
                        break;
                    default:
                        mapBloc[i, j] = null;
                        break;
                }
            }
        }
        mapEntity = new TileBlocEntity[mapBloc.GetLength(0), mapBloc.GetLength(1)];
        

        //show map
        showMap();
}

private void showMap(){
//show map
for(int i = 0; i < mapBloc.GetLength(0); i++){
    for(int j = 0; j < mapBloc.GetLength(1); j++){
        if(mapBloc[i, j] == null){
            tileMapBloc.SetTile(new Vector3Int(j, i, 0), null);
            continue;
        }
        tileMapBloc.SetTile(new Vector3Int(j, i, 0), mapBloc[i, j].GetTile());
    }
}
for(int i = 0; i < mapEntity.GetLength(0); i++){
    for(int j = 0; j < mapEntity.GetLength(1); j++){
        if(mapEntity[i, j] != null){
            tileMapEntity.SetTile(new Vector3Int(j, i, 0), mapEntity[i, j].GetTile());
        }else{
            tileMapEntity.SetTile(new Vector3Int(j, i, 0), null);
        }
    }
}
}

public void ForceInteract(Vector2Int gridPosition){
//force interact with bloc
if(mapEntity[gridPosition.y, gridPosition.x] != null){
    mapEntity[gridPosition.y, gridPosition.x].OnInteract();
}
showMap();
}

public bool IsWalkable(Vector2Int gridPosition){
//check if bloc is walkable
if(gridPosition.x < 0 || gridPosition.x >= mapBloc.GetLength(1) || gridPosition.y < 0 || gridPosition.y >= mapBloc.GetLength(0)){
    return false;
}
if(mapBloc[gridPosition.y, gridPosition.x].IsWalkable() && (mapEntity[gridPosition.y, gridPosition.x] == null)){
    return true;
}else if(mapEntity[gridPosition.y, gridPosition.x] != null && mapEntity[gridPosition.y, gridPosition.x].IsWalkable()){
    mapEntity[gridPosition.y, gridPosition.x].OnWalk();
    return true;
}
return false;
}

private void InteractUnit(Vector2Int gridPosition){
//interact with unit
if(gridPosition.x < 0 || gridPosition.x >= mapBloc.GetLength(1) || gridPosition.y < 0 || gridPosition.y >= mapBloc.GetLength(0)){
    return;
}
if(mapEntity[gridPosition.y, gridPosition.x] != null)
    mapEntity[gridPosition.y, gridPosition.x].OnInteract();
}
public void Interact(Vector2Int gridPosition){
//interact with bloc
for(int i = -1; i <= 1; i++){
    for(int j = -1; j <= 1; j++){
        InteractUnit(gridPosition + new Vector2Int(i, j));
    }
}
showMap();
}

private bool IsInteractableUnit(Vector2Int gridPosition){
//check if unit is interactable
if(gridPosition.x < 0 || gridPosition.x >= mapBloc.GetLength(1) || gridPosition.y < 0 || gridPosition.y >= mapBloc.GetLength(0)){
    return false;
}
return mapEntity[gridPosition.y, gridPosition.x] != null && mapEntity[gridPosition.y, gridPosition.x].IsInteractable();
}
public bool IsInteractableTile(Vector2Int gridPosition){
//check if tile is interactable
for(int i = -1; i <= 1; i++){
    for(int j = -1; j <= 1; j++){
        if(IsInteractableUnit(gridPosition + new Vector2Int(i, j))){
            return true;
        }
    }
}
return false;
}

public void UpdateTile(Vector2Int gridPosition){
//set tile
if(mapEntity[gridPosition.y, gridPosition.x] != null){
    tileMapEntity.SetTile(new Vector3Int(gridPosition.x, gridPosition.y, 0), mapEntity[gridPosition.y, gridPosition.x].GetTile());
}else{
    tileMapEntity.SetTile(new Vector3Int(gridPosition.x, gridPosition.y, 0), null);
}

if(mapBloc[gridPosition.y, gridPosition.x] != null){
    tileMapBloc.SetTile(new Vector3Int(gridPosition.x, gridPosition.y, 0), mapBloc[gridPosition.y, gridPosition.x].GetTile());
}else{
    tileMapBloc.SetTile(new Vector3Int(gridPosition.x, gridPosition.y, 0), null);
}
}

public void RemoveTileEntity(Vector2Int gridPosition){
//remove tile entity
mapEntity[gridPosition.y, gridPosition.x] = null;
showMap();
}
}
