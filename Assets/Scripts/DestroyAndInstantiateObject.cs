using UnityEngine;

public class DestroyAndInstantiateObject : MonoBehaviour
{
    
    public void DestroyGameObject(float time){
        Destroy(gameObject, time);
    }
    
    public void InstantiateGameObject(GameObject gObj, Vector3 position, Quaternion rotation){
        Instantiate(gObj, position, rotation);
    }
    
    public void PlayerExploded(){
        //TODO Trigger para explodir o que entrar no caminho da explosão do missile
        Debug.Log("Player Explodiu");
    }
    
    public void IAExploded(){
        Debug.Log("IA Explodiu");
    }
}
