using UnityEngine;

public class Fired : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D temporary_Rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(gameObject.transform.forward);
        Debug.Log(gameObject.transform.forward * 10);
        temporary_Rigidbody2D.AddForce(gameObject.transform.forward * 10 * Time.deltaTime, ForceMode2D.Impulse);
        Destroy(temporary_Rigidbody2D, 8f);        
    }
}
