using UnityEngine;

public class Grass : TileBloc{
    public Grass(Vector2Int pos){
        this.tile = BlocManager.instance.GetTile("Grass");
        this.isWalkable = true;
        this.position = pos;
    }
}

