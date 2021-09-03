using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject parent;
    [SerializeField] private float movSpeed = 5;
    
    [SerializeField] private GameObject bullet_Spawn_Point;
    [SerializeField] private GameObject bullet;
    public float bullet_Forward_Force;
    
    private bool moving = false;
    private GameObject cannon;
    private Rigidbody2D rb;
    private Vector2 movDirection;
    private Vector3 mouseWorldPosition;
    
    void Start()
    {
        cannon = parent.transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        TankFire();
        MousePositionMovement();     
        CannonRotationChange();        
    }
    
    private void TankFire(){
        if(Input.GetButtonDown("Fire1")){
            Debug.Log("Shoot");
            FireBullet();
    }
    }
    
    private void MousePositionMovement(){        
        if(Input.GetButtonDown("Fire2")){
            Debug.Log("Move");            
            mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            movDirection = (mouseWorldPosition - transform.position).normalized;
            moving = true;
        }
        if(moving){
            rb.velocity = new Vector2(movDirection.x * movSpeed, movDirection.y * movSpeed);            
            if(Vector2.Distance((Vector2)transform.position, (Vector2)mouseWorldPosition) <= 0.2){
                moving = false;
            }
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
    
    private void CannonRotationChange(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            Debug.Log("Up");     
            cannon.transform.Rotate(0,0,15);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            Debug.Log("Down");
            cannon.transform.Rotate(0,0,-15);            
        }
    }    
    
    public void FireBullet(){
        GameObject temporary_Game_Object;
        temporary_Game_Object = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation) as GameObject;
        
        Rigidbody2D temporary_Rigidbody2D;
        temporary_Rigidbody2D = temporary_Game_Object.GetComponent<Rigidbody2D>();        
        temporary_Rigidbody2D.AddForce(bullet_Spawn_Point.transform.forward * bullet_Forward_Force);
        
        Destroy(temporary_Game_Object, 10f);
    }
}