using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SpriteObject", menuName = "ScriptableObjects/SpriteObject", order = 1)]
public class SpriteObject : ScriptableObject{
    public string value;
    public Sprite sprite;

}
