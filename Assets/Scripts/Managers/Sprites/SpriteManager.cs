using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour{
    public static SpriteManager instance;

    public string path = "Sprites/";

    public List<SpriteObject> sprites;

    public bool showSpriteList = false;

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

    public Sprite getSprite(string value){
        foreach(SpriteObject sprite in sprites){
            if(sprite.value == value){
                return sprite.sprite;
            }
        }
        return null;
    }

}
