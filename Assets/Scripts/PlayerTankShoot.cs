using UnityEngine;

public class PlayerTankShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet_Spawn_Point;
    [SerializeField] private GameObject bullet;
    public float bullet_Forward_Force;
    
    public void FireBullet(){
        GameObject temporary_Game_Object;
        temporary_Game_Object = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation) as GameObject;
        
        Rigidbody2D temporary_Rigidbody2D;
        temporary_Rigidbody2D = temporary_Game_Object.GetComponent<Rigidbody2D>();        
        temporary_Rigidbody2D.AddForce(transform.forward * bullet_Forward_Force);
        
        Destroy(temporary_Game_Object, 10f);
    }
}
