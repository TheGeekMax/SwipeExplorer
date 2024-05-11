using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraManager : MonoBehaviour{
    public static CameraManager instance;

    public GameObject Background;

    public float horizontalSize = 6;

    public float cameraSpeed = 0.5f;

    [Header("Camera Grid Datas")]
    public int caseWidth = 10;

    private Vector2Int gridPosition;

    public GameObject LightRoom;

    private GameObject[,] lights;

    public TextMeshProUGUI fpsText;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        //initialise manager
        float aspectRatio = Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalSize / aspectRatio;

        Camera.main.transform.position = new Vector3(caseWidth/2,caseWidth/2, -10);

        gridPosition = new Vector2Int(0,0);

        //set up lights
        int wi = MapManager.instance.gridWidth;
        int he = MapManager.instance.gridHeight;
        lights = new GameObject[wi, he];
        for(int i = 0; i < wi; i++){
            for(int j = 0; j < he; j++){
                lights[i,j] = null;
            }
        }
    }

    private void calculateGridPosition(){
        Vector2Int playerPosition = PlayerManager.instance.getPlayerGridPosition();
        Vector2Int offset = new Vector2Int(caseWidth/2, caseWidth/2);
        gridPosition = (playerPosition/(caseWidth+1))*(caseWidth+1) + offset;
    }

    private void AddLightIfNeeded(){
        //depend on player position
        Vector2Int playerPosition = PlayerManager.instance.getPlayerGridPosition();
        Vector2Int offset = new Vector2Int(caseWidth/2, caseWidth/2);
        Vector2Int gridPosition = (playerPosition/(caseWidth+1))*(caseWidth+1) + offset;
        Vector2Int casePos = new Vector2Int(gridPosition.x/caseWidth, gridPosition.y/caseWidth);

        //check if light is already there
        if(lights[casePos.x, casePos.y] == null){
            //create light
            GameObject light = Instantiate(LightRoom, new Vector3(casePos.x*(caseWidth+1), casePos.y*(caseWidth+1), 0), Quaternion.identity);
            lights[casePos.x, casePos.y] = light;
        }
    }
    
    public void Shake(Vector2 direction){
        LeanTween
            .move(Camera.main.gameObject, Camera.main.transform.position + new Vector3(direction.x*.5f, direction.y*.5f, 0),
                0.5f)
            .setEase(LeanTweenType.punch);
    }

    void Update(){
        calculateGridPosition();
        
        //update fps
        fpsText.text = (1.0f / Time.deltaTime).ToString("F0");
        
        //lerp to grid position
        Vector3 targetPosition = new Vector3(gridPosition.x+.5f, gridPosition.y+.5f, -10);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, cameraSpeed*Time.deltaTime);
        Background.transform.position = Camera.main.transform.position-new Vector3(0,0,Camera.main.transform.position.z+1);
        AddLightIfNeeded();

        
    }
}
