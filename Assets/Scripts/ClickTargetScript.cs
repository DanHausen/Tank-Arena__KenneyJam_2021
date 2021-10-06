using UnityEngine;

public class ClickTargetScript : DestroyAndInstantiateObject
{
    void Start()
    {
        DestroyGameObject(0.4f);
    }
}
