using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCell{
    public bool visited = false;
    public bool wallUp = true;
    public bool wallDown = true;
    public bool wallLeft = true;
    public bool wallRight = true;

    public int x, y;

    public SimpleCell(int x, int y){
        this.x = x;
        this.y = y;
    }

}
