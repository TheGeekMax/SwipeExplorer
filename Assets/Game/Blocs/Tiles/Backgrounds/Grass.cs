using UnityEngine;

public class Grass : TileBloc{
    public Grass(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Grass");
        this.IsWalkable = true;
        
        //pos
        this.position = pos;
    }
    
    public override string GetId(){
        return "grass";
    }
}

