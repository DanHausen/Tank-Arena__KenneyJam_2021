using UnityEngine;

public class DestroyAndInstantiateObject : MonoBehaviour
{
    
    public void DestroyGameObject(float time){
        Destroy(gameObject, time);
    }
    
    public void InstantiateGameObject(GameObject gObj, Vector3 position, Quaternion rotation){
        Instantiate(gObj, position, rotation);
    }
}
