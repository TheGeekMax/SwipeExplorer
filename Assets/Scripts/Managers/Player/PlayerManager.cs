using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instance;

    [SerializeField]
    private Player player;
    
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

    public Player GetPlayer(){
        return player;
    }

    public Vector2Int getPlayerGridPosition(){
        return player.GetGridPosition();
    }
}
