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
    
    private bool moving = false;
    private GameObject cannon;
    private Rigidbody2D rb;
    private Vector2 movDirection;
    private Vector3 mouseWorldPosition;
    private Vector3 screenPoint;
    private bool onScreen;
    
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
            FireBullet();
        }
    }
    
    private void MousePositionMovement(){        
        if(Input.GetButtonDown("Fire2"))
        {
            mouseWorldPosition = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);//Captura a posição do click
            moving = true; //Ativa a movimentação

            VerifyClickPositionInsideCamLimits();

            //movDirection = (mouseWorldPosition - transform.position).normalized;
        }
        if (moving && onScreen){
            transform.position = Vector2.MoveTowards(transform.position, mouseWorldPosition, movSpeed * Time.deltaTime);            // Move o jogador em direção ao click do mouse
            if(Vector2.Distance((Vector2)transform.position, (Vector2)mouseWorldPosition) <= 0.1){
                //Essa é a condição para pausar a movimentação do jogador se já chegou na posição do click
                moving = false;
            }
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }

    private void VerifyClickPositionInsideCamLimits()
    {
        screenPoint = mainCam.WorldToViewportPoint(mouseWorldPosition); //Pega a posição do click em relação ao que a camera vê
        onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; //Compara a posição do que a camera vê com limites, se estiver dentro do limite é True.
    }

    private void CannonRotationChange(){
        //TODO Parece que não está tão facil de relacionar a rotação do canhão com o wheel e a movimentação. Parece estar confuso.
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            cannon.transform.Rotate(0,0,15);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            cannon.transform.Rotate(0,0,-15);            
        }
    }    
    
    public void FireBullet(){        
        GameObject temporary_Rigidbody2D;
        temporary_Rigidbody2D = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation);        
    }
}