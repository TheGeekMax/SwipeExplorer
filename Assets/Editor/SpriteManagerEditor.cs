using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteManager))]
public class SpriteManagerEditor : Editor{
    public override void OnInspectorGUI(){
        SpriteManager spriteManager = (SpriteManager)target;

        EditorGUILayout.LabelField("Path", spriteManager.path);
        if(GUILayout.Button("Choose Path")){
            string path = EditorUtility.OpenFolderPanel("Choose Path", Application.dataPath, "");
            if(path != ""){
                path = path.Replace(Application.dataPath, "Assets");
                spriteManager.path = path;
            }
        }

        if(GUILayout.Button("Add Sprite")){
            spriteManager.sprites = new List<SpriteObject>();
            //read all SpriteObjects (scriptable object) in the path
            string[] guids = AssetDatabase.FindAssets("t:SpriteObject", new string[]{spriteManager.path});
            foreach(string guid in guids){
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                SpriteObject spriteObject = (SpriteObject)AssetDatabase.LoadAssetAtPath(assetPath, typeof(SpriteObject));
                spriteManager.sprites.Add(spriteObject);
            }
        }

        //show all sprites
        bool endLine = false;
        spriteManager.showSpriteList = EditorGUILayout.Foldout(spriteManager.showSpriteList, "Sprites");
        if(spriteManager.showSpriteList){
            foreach(SpriteObject sprite in spriteManager.sprites){
                if(!endLine)
                    EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();
                GUI.enabled = false;
                EditorGUILayout.ObjectField(sprite.sprite, typeof(Sprite), false, GUILayout.Width(50), GUILayout.Height(50));
                GUI.enabled = true;
                EditorGUILayout.LabelField(sprite.value);
                EditorGUILayout.EndVertical();
                if(endLine)
                    EditorGUILayout.EndHorizontal();

                endLine = !endLine;
            }
            if(endLine)
                EditorGUILayout.EndHorizontal();
        }
    }

}
