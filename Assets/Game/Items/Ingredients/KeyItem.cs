using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item{
    protected override void SetDatas(){
        Icon = SpriteManager.instance.getSprite("key");
        Name = "Key";
    }

    public override string GetId(){
        return "key";
    }
}
