using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 3f;
    public float minY = 10f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update(){

        if(GameManager.gameIsOver){
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown("m")){
            doMovement = !doMovement;
        }

        if(!doMovement){
            return;
        }

        //camera moviment up
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
            
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        //camera movement down
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){
            
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment right
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){
            
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //camera moviment left
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){
            
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }     


        //scroll zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000; 
        pos.y = Mathf.Clamp(pos.y, minY, maxY);  
        transform.position = pos;
        
    }
}
