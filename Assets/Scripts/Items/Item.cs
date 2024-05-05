using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item{
    public int Damage {get; protected set; } = 0;
    public DamageType DamageType {get; protected set; } = DamageType.None;
    public EquipType EquipType {get; protected set; } = EquipType.None;
    public Sprite Icon {get; protected set; } = null;
    public string Name {get; protected set; } = "";

    public Item(){
        SetDatas();
    }

    protected virtual void SetDatas(){
        Damage = 0;
        DamageType = DamageType.None;
        EquipType = EquipType.None;
        Icon = null;
        Name = "";
    }

    public abstract string GetId();

    public virtual void Use(){
        Debug.Log("Using " + Name);
    }

    public virtual void Equip(){
        Debug.Log("Equipping " + Name);
    }

    public virtual bool canUse(){
        return false;
    }

    public virtual bool canEquip(){
        return false;
    }
}