using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item{
    protected override void SetDatas(){
        Icon = SpriteManager.instance.getSprite("coin");
        Name = "Coin";
    }

    public override string GetId(){
        return "coin";
    }
    
}
