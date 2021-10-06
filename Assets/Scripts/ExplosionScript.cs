using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : DestroyAndInstantiateObject
{
    public float timeToDestroy = 4f;
    
    void Start()
    {
        //TODO executar animação
        
        DestroyGameObject(timeToDestroy);
    }
}
