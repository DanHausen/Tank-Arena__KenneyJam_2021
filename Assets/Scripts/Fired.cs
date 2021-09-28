using UnityEngine;

public class Fired : DestroyObject
{
    public float bullet_Forward_Force = 10;
    public float timeToDestroy = 4f;
    
    void Start()
    {
        Rigidbody2D temporary_Rigidbody2D = GetComponent<Rigidbody2D>();
        temporary_Rigidbody2D.AddForce(gameObject.transform.up * bullet_Forward_Force, ForceMode2D.Impulse);
        
        DestroyGameObject(timeToDestroy);
        //TODO Fazer as balas explodirem no final
    }
}
