using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour{
    public static PlayerInventoryManager instance;

    private List<Item> items;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        items = new List<Item>();

        items.Add(ItemSpawnerManager.instance.SpawnItem("testSword"));
        items.Add(ItemSpawnerManager.instance.SpawnItem("testItem"));
    }

    public List<Item> GetItems(){
        return items;
    }

    public void AddItem(Item item){
        items.Add(item);
        InventoryUIManager.instance.UpdateUI();
    }

    public void RemoveItem(int index){
        items.RemoveAt(index);
        InventoryUIManager.instance.UpdateUI();
    }

    public bool HasItem(string id){
        for(int i = 0; i < items.Count; i++){
            if(items[i].GetId() == id){
                return true;
            }
        }
        return false;
    }

    public void Consume(string id){
        for(int i = 0; i < items.Count; i++){
            if(items[i].GetId() == id){
                items.RemoveAt(i);
                InventoryUIManager.instance.UpdateUI();
                return;
            }
        }
    }
}
