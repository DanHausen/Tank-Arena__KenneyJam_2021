using UnityEngine;

public class Fired : DestroyAndInstantiateObject
{
    public float bullet_Forward_Force = 10;
    public float timeToDestroy = 4f;
    
    [SerializeField] private GameObject explosionGObj;
    
    void Start()
    {
        Rigidbody2D temporary_Rigidbody2D = GetComponent<Rigidbody2D>();
        temporary_Rigidbody2D.AddForce(gameObject.transform.up * bullet_Forward_Force, ForceMode2D.Impulse);
        
        DestroyGameObject(timeToDestroy);
    }
    
    void OnDestroy(){
        //TODO Fazer as balas explodirem no final. Instanciar a explosão
        InstantiateGameObject(explosionGObj, gameObject.transform.position, Quaternion.identity);
    }
}
