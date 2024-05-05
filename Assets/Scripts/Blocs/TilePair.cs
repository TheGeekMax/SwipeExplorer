using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "TilePair", menuName = "ScriptableObjects/TilePair", order = 1)]
public class TilePair: ScriptableObject{
    public new string name;
    public TileBase tile;
}
