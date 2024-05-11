using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelObject", menuName = "Level/LevelObject", order = 1)]
public class LevelObject : ScriptableObject{
    public new string name;
    public RoomData[] rooms;
}
