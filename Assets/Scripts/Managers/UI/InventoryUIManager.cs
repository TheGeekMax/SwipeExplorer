using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour{
    public static InventoryUIManager instance;

    public Sprite defaultNull = null;

    public Image[] itemsPlaceholders;
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        UpdateUI();
    }

    public void UpdateUI(){
        List<Item> items = PlayerInventoryManager.instance.GetItems();
        //reset all slots
        for (int i = 0; i < itemsPlaceholders.Length; i++){
            itemsPlaceholders[i].sprite = defaultNull;
        }

        //update slots
        for (int i = 0; i < items.Count; i++){
            itemsPlaceholders[i].sprite = items[i].Icon;
        }
    }

}
