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
            //TODO os tiros estão colidindo quando varios são atirados consecutivamente, preciso arrumar isso.
        }
    }
    
    private void MousePositionMovement(){        
        if(Input.GetButtonDown("Fire2")){
            mouseWorldPosition = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
            //movDirection = (mouseWorldPosition - transform.position).normalized;
            moving = true;
            //TODO preciso limitar o movimento do jogador para dentro da área do jogo. O jogador está saindo da cena quando clica fora
        }
        if(moving){
            transform.position = Vector2.MoveTowards(transform.position, mouseWorldPosition, movSpeed * Time.deltaTime);            
            if(Vector2.Distance((Vector2)transform.position, (Vector2)mouseWorldPosition) <= 0.2){
                moving = false;
            }
        }
        else{
            rb.velocity = Vector2.zero;
        }
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