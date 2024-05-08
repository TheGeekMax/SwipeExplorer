

public class Room{
    private int width;
    private int height;
    public bool[,] RoomGrid{ get; private set;}
    
    
    public Room(int width, int height){
        this.width = width;
        this.height = height;
        RoomGrid = new bool[width,height];
    }
    
    public void SetTile(int x, int y, bool value){
        RoomGrid[x,y] = value;
    }
    
    public bool[,] GetRoomGrid(){
        return RoomGrid;
    }
}