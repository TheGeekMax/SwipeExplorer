using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionManager : MonoBehaviour{
    public static PlayerInteractionManager instance;
    public Button InteractButton;

    private bool isButtonShown = false;
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
        isButtonShown = GetShown();
        updateInteractButton();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void updateInteractButton(){
        bool temp = GetShown();
        if (temp != isButtonShown){
            isButtonShown = temp;
            if (isButtonShown){
                UIManager.instance.InteractAppear();
            }
            else{
                UIManager.instance.InteractDisappear(null);
            }
        }
    }
    
    private bool GetShown(){
        return MapManager.instance.IsInteractableTile(instancePlayer.GetGridPosition());
    }

    public void Interact(){
        if (!isButtonShown) return;
        MapManager.instance.Interact(instancePlayer.GetGridPosition());
        updateInteractButton();
    }
}
