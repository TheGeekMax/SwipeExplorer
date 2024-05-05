using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour{
    public static InventoryUIManager instance;

    public Sprite defaultNull = null;

    public Image slot0;
    public Image slot1;
    public Image slot2;
    public Image slot3;
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
        slot0.sprite = defaultNull;
        slot1.sprite = defaultNull;
        slot2.sprite = defaultNull;
        slot3.sprite = defaultNull;

        if(items.Count > 0) slot0.sprite = items[0].Icon;
        if(items.Count > 1) slot1.sprite = items[1].Icon;
        if(items.Count > 2) slot2.sprite = items[2].Icon;
        if(items.Count > 3) slot3.sprite = items[3].Icon;
    }

}
