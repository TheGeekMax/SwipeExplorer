using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : Item{
    protected override void SetDatas(){
        Icon = SpriteManager.instance.getSprite("test_potion");
        Name = "Test Item";
    }

    public override string GetId(){
        return "testItem";
    }
}
