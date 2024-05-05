using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour{
    public static TouchManager instance;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    public void initialise(){

    }
    private Vector2 initPos;

    private bool skipSwipe = false;
    void Update(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                initPos = touch.position;
                if(touch.position.y < 300){
                    skipSwipe = true;
                }
            }else if(touch.phase == TouchPhase.Ended){
                if(skipSwipe){
                    skipSwipe = false;
                    return;
                }
                Vector2 swipe = touch.position - initPos;
                if(swipe.magnitude < 50){
                    return;
                }
                if(Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y)){
                    if(swipe.x > 0){
                        PlayerMovementManager.instance.right();
                    }else{
                        PlayerMovementManager.instance.left();
                    }
                }else{
                    if(swipe.y > 0){
                        PlayerMovementManager.instance.up();
                    }else{
                        PlayerMovementManager.instance.down();
                    }
                }
            }
        }

        //for testing on pc using arrow keys
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            PlayerMovementManager.instance.right();
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            PlayerMovementManager.instance.left();
        }else if(Input.GetKeyDown(KeyCode.UpArrow)){
            PlayerMovementManager.instance.up();
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            PlayerMovementManager.instance.down();
        }
    }
}
