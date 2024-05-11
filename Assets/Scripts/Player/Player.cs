using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{

    private Vector2Int gridPosition;
    private Vector2 position;
    [SerializeField]
    private AnimationCurve moveCurve;

    [SerializeField]
    private Sprite spriteFL;
    [SerializeField]

    private Sprite spriteFR;
    [SerializeField]

    private Sprite spriteBL;
    [SerializeField]

    private Sprite spriteBR;

    private bool front,left;

    void Start(){
        gridPosition = new Vector2Int(1, 1);
        position = new Vector2(gridPosition.x, gridPosition.y);
        //set player position
        transform.position = new Vector3(position.x, position.y, 0);
    }

    //movements
    public Vector2Int GetGridPosition(){
        return gridPosition;
    }

    public void SetGridPosition(Vector2Int gridPosition){
        //change player sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(gridPosition.x > this.gridPosition.x){
            left = false;
        }else if(gridPosition.x < this.gridPosition.x){
            left = true;
        }else if(gridPosition.y > this.gridPosition.y){
            front = false;
        }else if(gridPosition.y < this.gridPosition.y){
            front = true;
        }
        UpdateSprite();

        this.gridPosition = gridPosition;
        LeanTween.move(gameObject, new Vector3(gridPosition.x, gridPosition.y, 0), 0.2f)
            .setEase(moveCurve);
    }

    private void UpdateSprite(){
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(front){
            if(left){
                sr.sprite = spriteFL;
            }else{
                sr.sprite = spriteFR;
            }
        }else{
            if(left){
                sr.sprite = spriteBL;
            }else{
                sr.sprite = spriteBR;
            }
        }
    }
}
