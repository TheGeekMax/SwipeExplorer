using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndDoor : TileBlocEntity{
    string signal1, signal2;
    bool signal1Recieved, signal2Recieved;
    
    private bool used = false;
    public AndDoor(Vector2Int pos, string signal1, string signal2){
        this.tile = BlocManager.instance.GetTile("Door_closed");
        this.isWalkable = false;
        this.position = pos;

        //setup signal
        this.signal1 = signal1;
        this.signal2 = signal2;

        //subscribe to signals
        SignalManager.instance.Subscribe(signal1, OnSignal1);
        SignalManager.instance.Subscribe(signal2, OnSignal2);
    }

    public void OnSignal1(){
        signal1Recieved = true;
    }

    public void OnSignal2(){
        signal2Recieved = true;
    }

    public override void OnInteract(){
        if(signal1Recieved && signal2Recieved){
            this.tile = BlocManager.instance.GetTile("Door_open");
            this.isInteractable = false;
            this.isWalkable = true;
            used = true;
        }
    }

    public override bool IsInteractable(){
        return signal1Recieved && signal2Recieved && !used;
    }
}
