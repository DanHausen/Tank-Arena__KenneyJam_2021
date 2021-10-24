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
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag != "notExplode"){
            Destroy(gameObject);    
        }
    }
    
    private void BulletDestroyCallExplosion(){
        InstantiateGameObject(explosionGObj, gameObject.transform.position, Quaternion.identity);
    }
    
    private void OnDestroy(){
        //TODO 1 Adicionar animação de explosão do kit do Kenney. Removendo as particulas que inseri.
        BulletDestroyCallExplosion();
    }
}
