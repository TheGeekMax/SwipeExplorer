

using UnityEngine;

[System.Serializable]
public class RoomData{
        [Header("General")]
        public string label;
        public string levelString;
        
        [Header("Tiles")]
        public string wallId;
        public string floorId;
        
        //[Header("Input Output")]
        [Header("Tile Entities")]
        public TileEntityLevel[] tileEntities;
}