using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 0.3f;
    
    void Start()
    {
        DestroyGameObject(timeToDestroy);
    }
    
    public void DestroyGameObject(float time){
        Destroy(gameObject, time);
        
    }
}
