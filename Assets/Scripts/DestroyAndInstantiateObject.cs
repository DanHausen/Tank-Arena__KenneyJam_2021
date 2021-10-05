using UnityEngine;

public class DestroyAndInstantiateObject : MonoBehaviour
{
    
    public void DestroyGameObject(float time){
        Destroy(gameObject, time);
    }
    
    public void InstantiateGameObject(){
        
    }
}
