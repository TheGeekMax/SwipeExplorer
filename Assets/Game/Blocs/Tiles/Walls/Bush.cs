using UnityEngine;

public class Bush : TileBloc{
    public Bush(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Bush");
        this.IsWalkable = false;
        
        //pos
        this.position = pos;
    }
    
    public override string GetId(){
        return "bush";
    }
}