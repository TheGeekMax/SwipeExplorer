using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndDoor : TileBlocEntity{
    string signal1, signal2;
    bool signal1Recieved, signal2Recieved;
    
    public AndDoor(Vector2Int pos){
        this.TileSprite = BlocManager.instance.GetTile("Door_closed");
        this.position = pos;
        this.isWalkable = false;
    }

    public void OnSignal1(){
        signal1Recieved = true;
    }

    public void OnSignal2(){
        signal2Recieved = true;
    }

    public override void OnInteract(){
        if(signal1Recieved && signal2Recieved){
            this.TileSprite = BlocManager.instance.GetTile("Door_open");
            isWalkable = true;
        }
    }

    public override bool IsInteractable(){
        return signal1Recieved && signal2Recieved && !isWalkable;
    }
    
    public override string GetId(){
        return "and_door";
    }
    
    public override void SetupSignal(string prefix){
        signal1 = prefix + "_s1";
        signal2 = prefix + "_s2";
        
        SignalManager.instance.Subscribe(signal1, OnSignal1);
        SignalManager.instance.Subscribe(signal2, OnSignal2);
    }
}
