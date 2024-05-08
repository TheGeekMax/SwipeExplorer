using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator{
    private int width;
    private int height;

    private bool[,] room;

    private CellType[,] generatedRoom;

    private Labyrinth labyrinth;

    public RoomGenerator(int width, int height){
        this.width = width;
        this.height = height;

        bool f = false;
        bool t = true;

        RoomDecoder decoder = new RoomDecoder(15);
        Room currentRoom = decoder.DecodeRoom("//FWWzrDeWrrleWVLFYYLtj2erTD0WzrDWW///");
        room = currentRoom.GetRoomGrid();
    }

    private bool[,] rotate(bool[,] room){
        bool[,] newRoom = new bool[room.GetLength(0), room.GetLength(1)];
        for(int i = 0; i < room.GetLength(0); i++){
            for(int j = 0; j < room.GetLength(1); j++){
                newRoom[i, j] = room[j, room.GetLength(0)-1-i];
            }
        }
        return newRoom;
    }

    private bool[,] rotate(bool[,] room, int times){
        bool[,] newRoom = room;
        for(int i = 0; i < times; i++){
            newRoom = rotate(newRoom);
        }
        return newRoom;
    }

    public void Generate(){
        this.labyrinth = new Labyrinth(this.width, this.height);
        this.labyrinth.Generate();
        this.generatedRoom = new CellType[this.height*16-1, this.width*16-1];

        for(int i = 0; i < this.height*16-1; i++){
            for(int j = 0; j < this.width*16-1; j++){
                this.generatedRoom[i, j] = CellType.NULL;
            }
        }

        for(int i = 0; i < this.height; i++){
            for(int j = 0; j < this.width; j++){
                bool[,] cRoom = rotate(this.room, Random.Range(0, 4));
                for(int x = 0; x < 15; x++){
                    for(int y = 0; y < 15; y++){
                        this.generatedRoom[i*16+y, j*16+x] = (cRoom[x, y])?CellType.WALL:CellType.FLOOR;
                    }
                }
                //add corridors
                SimpleCell c = this.labyrinth.GetCell(j, i);
                if(!c.wallDown){
                    this.generatedRoom[i*16+14, j*16+7] = CellType.FLOOR;
                    this.generatedRoom[i*16+15, j*16+7] = CellType.FLOOR;
                    this.generatedRoom[i*16+15, j*16+6] = CellType.WALL;
                    this.generatedRoom[i*16+15, j*16+8] = CellType.WALL;
                }
                if(!c.wallUp){
                    this.generatedRoom[i*16, j*16+7] = CellType.FLOOR;
                    this.generatedRoom[i*16-1, j*16+7] = CellType.FLOOR;
                    this.generatedRoom[i*16-1, j*16+6] = CellType.WALL;
                    this.generatedRoom[i*16-1, j*16+8] = CellType.WALL;
                }
                if(!c.wallLeft){
                    this.generatedRoom[i*16+7, j*16] = CellType.FLOOR;
                    this.generatedRoom[i*16+7, j*16-1] = CellType.FLOOR;
                    this.generatedRoom[i*16+6, j*16-1] = CellType.WALL;
                    this.generatedRoom[i*16+8, j*16-1] = CellType.WALL;
                }
                if(!c.wallRight){
                    this.generatedRoom[i*16+7, j*16+14] = CellType.FLOOR;
                    this.generatedRoom[i*16+7, j*16+15] = CellType.FLOOR;
                    this.generatedRoom[i*16+6, j*16+15] = CellType.WALL;
                    this.generatedRoom[i*16+8, j*16+15] = CellType.WALL;
                }
            }
        }
    }

    public CellType[,] GetRoom(){
        return this.generatedRoom;
    }
}
