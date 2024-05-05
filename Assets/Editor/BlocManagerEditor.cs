using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CustomEditor(typeof(BlocManager))]
public class BlocManagerEditor : Editor{
    public override void OnInspectorGUI(){
        BlocManager blocManager = (BlocManager)target;

        EditorGUILayout.LabelField("Path", blocManager.path);
        if(GUILayout.Button("Choose Path")){
            string path = EditorUtility.OpenFolderPanel("Choose Path", Application.dataPath, "");
            if(path != ""){
                path = path.Replace(Application.dataPath, "Assets");
                blocManager.path = path;
            }
        }

        if(GUILayout.Button("Add Tile")){
            blocManager.tilePairs = new List<TilePair>();
            //read all TilePair (scriptable object) in the path
            string[] guids = AssetDatabase.FindAssets("t:TilePair", new string[]{blocManager.path});
            foreach(string guid in guids){
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                TilePair tilePair = (TilePair)AssetDatabase.LoadAssetAtPath(assetPath, typeof(TilePair));
                blocManager.tilePairs.Add(tilePair);
            }
        }

        //show all tiles
        bool endLine = false;
        blocManager.showTileList = EditorGUILayout.Foldout(blocManager.showTileList, "Tiles");
        if(blocManager.showTileList){
            foreach(TilePair tilePair in blocManager.tilePairs){
                if(!endLine)
                    EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();
                GUILayout.Box(AssetPreview.GetAssetPreview(tilePair.tile), GUILayout.Width(50), GUILayout.Height(50));
                EditorGUILayout.LabelField(tilePair.name);
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
