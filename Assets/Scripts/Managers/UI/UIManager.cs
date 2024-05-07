using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class UIManager : MonoBehaviour{
    public static UIManager instance;

    public GameObject test;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void initialise() {
        //put test 1 screen down
        LeanTween.move(test, new Vector3(0, -Screen.height, 0), 0);
    }
}
