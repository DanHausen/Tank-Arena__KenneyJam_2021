using UnityEngine;
using UnityEngine.UI;

public class SliderColorFeedbackScript : MonoBehaviour
{
    private static Image _image;
    
    void Start(){
        _image = gameObject.GetComponentInChildren<Image>();
    }
    
    public static void SliderColorUpdater(float ammo){
        switch(ammo){
            case 0:
                _image.color = Color.red;
                break;
            case 1:
                _image.color = Color.red;
                break;
            case 2:
                _image.color = Color.yellow;
                break;
            case 3:
                _image.color = Color.green;
                break;
        }
    }
}
