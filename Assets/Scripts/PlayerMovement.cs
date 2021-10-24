using UnityEngine;

public class PlayerMovement : DestroyAndInstantiateObject
{    
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject parent;
    [SerializeField] private float movSpeed = 4;  
    [SerializeField] private GameObject click_target;    
    
    [SerializeField] private GameObject _bullet_Spawn_Point;
    [SerializeField] private GameObject _bullet;    
    
    public static int _ammoAmount = 3;   
    
    private bool moving = false;
    private GameObject cannon;
    private Rigidbody2D rb;
    //private Vector2 movDirection;
    private UnityEngine.Vector3 mouseWorldPosition;
    private UnityEngine.Vector3 screenPoint;
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
            
            InstantiateGameObject(click_target, mouseWorldPosition, Quaternion.identity);
            VerifyClickPositionInsideCamLimits();
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
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            cannon.transform.Rotate(0,0,15);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            cannon.transform.Rotate(0,0,-15);            
        }
    }
    
    private void FireBullet(){
        if (_ammoAmount > 0){
            GameObject temporary_Rigidbody2D;
            temporary_Rigidbody2D = Instantiate(_bullet, _bullet_Spawn_Point.transform.position, _bullet_Spawn_Point.transform.rotation);
            _ammoAmount--;
            BackTankForceWhenFired();
        }
    }
    
    private void BackTankForceWhenFired(){
        rb.AddForce(-cannon.transform.up * 800f); 
        moving = false;
    }
}