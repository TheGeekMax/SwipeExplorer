using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellType{
    public static CellType NULL = new CellType("null");

    public string id;

    public CellType(string id){
        this.id = id;
    }
    
    
    public override bool Equals(object obj){
        if(obj == null || GetType() != obj.GetType()){
            return false;
        }
        
        CellType c = (CellType) obj;
        return c.id == this.id;
    }
    
}
