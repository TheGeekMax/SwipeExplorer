using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class UIManager : MonoBehaviour{
    public static UIManager instance;

    public GameObject interactButton;

    public GameObject main;
    public GameObject inventory;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void initialise() {
        //put test 1 screen down
        LeanTween.move(inventory, new Vector3(Screen.width/2, -Screen.height, 0), 0);
        
        //scaling
        LeanTween.scale(interactButton, new Vector3(0, 0, 0), 0);
    }
    
    public void ShowInventory(){
        LeanTween.move(main, new Vector3(Screen.width*2, Screen.height/2, 0), .5f)
            .setEase(LeanTweenType.easeOutBack);
        LeanTween.move(inventory, new Vector3(Screen.width/2, Screen.height/2, 0), .5f)
            .setEase(LeanTweenType.easeOutBack)
            .setDelay(.2f);
    }
    
    public void HideInventory(){
        LeanTween.move(main, new Vector3(Screen.width/2, Screen.height/2, 0), .5f)
            .setEase(LeanTweenType.easeOutBack)
            .setDelay(.2f);
        LeanTween.move(inventory, new Vector3(Screen.width/2, -Screen.height, 0), .5f)
            .setEase(LeanTweenType.easeOutBack);
    }
    
    public void InteractAppear(){
        LeanTween.scale(interactButton, new Vector3(1, 1, 1), .2f)
            .setEase(LeanTweenType.easeOutBack);
    }
    
    public void InteractDisappear(Action callback){
        LeanTween.scale(interactButton, new Vector3(0, 0, 0), .2f)
            .setEase(LeanTweenType.easeInBack)
            .setOnComplete(() => {
                callback?.Invoke();
            });
    }
}
