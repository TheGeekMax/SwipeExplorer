using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : Item{
    protected override void SetDatas(){
        Icon = SpriteManager.instance.getSprite("test_sword");
        Name = "Test Sword";
        Damage = 10;
        DamageType = DamageType.Melee;
    }

    public override string GetId(){
        return "testSword";
    }
}  
