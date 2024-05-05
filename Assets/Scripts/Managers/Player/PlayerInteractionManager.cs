using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionManager : MonoBehaviour{
    public static PlayerInteractionManager instance;
    public Button InteractButton;


    private Player instancePlayer;
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager 
        instancePlayer = PlayerManager.instance.GetPlayer();  
        updateInteractButton();
    }

    public void updateInteractButton(){
        InteractButton.gameObject.SetActive(MapManager.instance.IsInteractableTile(instancePlayer.GetGridPosition()));
    }

    public void Interact(){
        MapManager.instance.Interact(instancePlayer.GetGridPosition());
        updateInteractButton();
    }
}
