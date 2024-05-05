using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerManager : MonoBehaviour{
    public static ItemSpawnerManager instance;
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
    }

    public Item SpawnItem(string id){
        return ItemIdManager.instance.InstantiateItem(id);
    }
}
