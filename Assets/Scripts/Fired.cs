using UnityEngine;

public class Fired : MonoBehaviour
{
    public float bullet_Forward_Force = 10;
    
    void Start()
    {
        Rigidbody2D temporary_Rigidbody2D = GetComponent<Rigidbody2D>();
        temporary_Rigidbody2D.AddForce(gameObject.transform.up * bullet_Forward_Force, ForceMode2D.Impulse);
        Destroy(temporary_Rigidbody2D, 8f);
    }
}
