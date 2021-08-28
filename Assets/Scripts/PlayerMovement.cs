using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject parent;
    [SerializeField] private float movSpeed = 5;
    
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
            //PlayerTankShoot.FireBullet(); TODO chamar metodo de outra classe para atirar a bala na direção do canhão
    }
    }
    
    private void MousePositionMovement(){        
        if(Input.GetButtonDown("Fire2")){
            Debug.Log("Move");            
            mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            movDirection = (mouseWorldPosition - transform.position).normalized;
            moving = true;
            // TODO fazer o jogador parar quando chegar na posição. Está dando erro para pegar a diferença das distancias
        }
        if(moving){
            if((Vector2)mouseWorldPosition - rb.position == new Vector2(0,0)){
                moving = false;
            }
            rb.velocity = new Vector2(movDirection.x * movSpeed, movDirection.y * movSpeed);
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