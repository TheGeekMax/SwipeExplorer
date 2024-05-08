
using UnityEngine;

public class RoomDecoder{
    private Alphabet alphabet;
    private int size;
    
    public RoomDecoder(int size){
        this.alphabet = new Alphabet(Alphabet.default64, 6);
        this.size = size;
    }
    
    public Room DecodeRoom(string room){
        Room newRoom = new Room(size, size);
        int[] binary = new int[6];
        int index = 6;
        int sIndex = 0;
        for (int i = 0; i < size; i++){
            for (int j = 0; j < size; j++){
                if (index == 6){
                    index = 0;
                    binary = alphabet.tobinary(room[sIndex]);
                    sIndex++;
                    Debug.Log(i+" "+j);
                }
                newRoom.SetTile(j, i, binary[index] == 1);
                index++;
            }
        }
        return newRoom;
    }
    
    //temporaire
    public string EncodeRoom(Room room){
        string result = "";
        int[] binary = new int[6];
        bool[,] grid = room.GetRoomGrid();
        for (int i = 0; i < size; i++){
            for (int j = 0; j < size; j++){
                int linearIndex = i * size + j;
                if (linearIndex % 6 == 0){
                    if (linearIndex != 0){
                        result += alphabet.frombinary(binary);
                    }
                    binary = new int[6];
                }
                binary[linearIndex % 6] = grid[i, j] ? 1 : 0;
            }
        }
        result += alphabet.frombinary(binary);
        return result;
    }

}