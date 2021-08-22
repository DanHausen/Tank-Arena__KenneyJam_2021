using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject parent;
    [SerializeField] private float movSpeed = 1;
    
    private GameObject cannon;
    private bool moving = false;
    private Vector3 movDirection = new Vector3(0,0,0);
    private Vector3 mouseWorldPosition = new Vector3(0,0,0);
    
    void Start()
    {
        cannon = parent.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {        
        TankFire();
        MousePositionMovement();     
        CannonRotationChange();        
    }
    
    private void TankFire(){
        if(Input.GetButtonDown("Fire1")){
            Debug.Log("Fire");
        }    
    }
    
    private void MousePositionMovement(){        
        if(Input.GetButtonDown("Fire2")){
            Debug.Log("Move");            
            mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            movDirection = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0);
            movDirection.Normalize();
            moving = true;
        }
        if(moving){
            if(gameObject.transform.position != movDirection){
                transform.Translate(movDirection * movSpeed * Time.deltaTime, Space.World);
                }
            }
    }
    
    private void CannonRotationChange(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            Debug.Log("Up");     
            cannon.transform.Rotate(0,0,10);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            Debug.Log("Down");
            cannon.transform.Rotate(0,0,-10);            
        }
    }
}