using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator{
    private int width;
    private int height;
    private LevelObject activeLevel;

    private CellType[,] generatedRoom;
    private string[,] tileSetRoom;

    private Labyrinth labyrinth;
    

    public RoomGenerator(int width, int height, LevelObject activeLevel){
        this.width = width;
        this.height = height;
        this.activeLevel = activeLevel;
    }

    private T[,] rotate<T>(T[,] room){
        T[,] newRoom = new T[room.GetLength(0), room.GetLength(1)];
        for(int i = 0; i < room.GetLength(0); i++){
            for(int j = 0; j < room.GetLength(1); j++){
                newRoom[i, j] = room[j, room.GetLength(0)-1-i];
            }
        }
        return newRoom;
    }

    private T[,] rotate<T>(T[,] room, int times){
        T[,] newRoom = room;
        for(int i = 0; i < times; i++){
            newRoom = rotate(newRoom);
        }
        return newRoom;
    }

    public void Generate(){
        this.labyrinth = new Labyrinth(this.width, this.height);
        this.labyrinth.Generate();
        this.generatedRoom = new CellType[this.height*16-1, this.width*16-1];
        this.tileSetRoom = new string[this.height*16-1, this.width*16-1];
        RoomDecoder decoder = new RoomDecoder(15);
        

        for(int i = 0; i < this.height*16-1; i++){
            for(int j = 0; j < this.width*16-1; j++){
                this.generatedRoom[i, j] = CellType.NULL;
                this.tileSetRoom[i, j] = null;
            }
        }

        for(int i = 0; i < this.height; i++){
            for(int j = 0; j < this.width; j++){
                RoomData currentRoom = activeLevel.rooms[0];
                
                //get room
                bool [,] room = decoder.DecodeRoom(currentRoom.levelString).GetRoomGrid();
                string[,] tileRoom = new string[15, 15];
                for(int k = 0; k < currentRoom.tileEntities.Length; k++){
                    TileEntityLevel entity = currentRoom.tileEntities[k];
                    tileRoom[entity.position.x, entity.position.y] = entity.id;
                }

                int r = Random.Range(0, 4);
                bool[,] cRoom = rotate(room, r);
                string[,] cTileRoom = rotate(tileRoom, r);
                
                CellType floor = new CellType(currentRoom.floorId);
                CellType wall = new CellType(currentRoom.wallId);
                for(int x = 0; x < 15; x++){
                    for(int y = 0; y < 15; y++){
                        this.generatedRoom[i*16+y, j*16+x] = (cRoom[x, y])?wall:floor;
                        this.tileSetRoom[i*16+y, j*16+x] = (cRoom[x, y])?null:cTileRoom[x, y];
                    }
                }
                //add corridors
                SimpleCell c = this.labyrinth.GetCell(j, i);
                if(!c.wallDown){
                    this.generatedRoom[i*16+14, j*16+7] = floor;
                    this.generatedRoom[i*16+15, j*16+7] = floor;
                    this.generatedRoom[i*16+15, j*16+6] = wall;
                    this.generatedRoom[i*16+15, j*16+8] = wall;
                }
                if(!c.wallUp){
                    this.generatedRoom[i*16, j*16+7] = floor;
                    this.generatedRoom[i*16-1, j*16+7] = floor;
                    this.generatedRoom[i*16-1, j*16+6] = wall;
                    this.generatedRoom[i*16-1, j*16+8] = wall;
                }
                if(!c.wallLeft){
                    this.generatedRoom[i*16+7, j*16] = floor;
                    this.generatedRoom[i*16+7, j*16-1] = floor;
                    this.generatedRoom[i*16+6, j*16-1] = wall;
                    this.generatedRoom[i*16+8, j*16-1] = wall;
                }
                if(!c.wallRight){
                    this.generatedRoom[i*16+7, j*16+14] = floor;
                    this.generatedRoom[i*16+7, j*16+15] = floor;
                    this.generatedRoom[i*16+6, j*16+15] = wall;
                    this.generatedRoom[i*16+8, j*16+15] = wall;
                }
            }
        }
    }

    public CellType[,] GetRoom(){
        return this.generatedRoom;
    }
    
    public string[,] GetTileSet(){
        return this.tileSetRoom;
    }
}
