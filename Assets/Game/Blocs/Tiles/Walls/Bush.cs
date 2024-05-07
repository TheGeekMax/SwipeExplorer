using UnityEngine;

public class Bush : TileBloc{
    public Bush(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("Bush");
        this.isWalkable = false;
        this.position = pos;
    }
}