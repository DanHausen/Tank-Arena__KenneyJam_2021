using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 0.3f;
    
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
