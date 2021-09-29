using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 3;
    [SerializeField] private Text scorePointsText;    
    [SerializeField] private GameObject bullet_Spawn_Point;
    [SerializeField] private GameObject bullet;    
    
    public Slider ammoSlider;
    
    //TODO Criar mecanica para spawnar inimigos neste script e tambem evoluir na dificuldade
    //TODO Aqui tambem vai o temporizador e leaderboard
    //TODO seria bacana adicionar power ups
    
    void Start(){
        AmmoCounterSliderUpdate(ammoAmount);
    }
    
    public bool FiredBullet(){
        if (ammoAmount > 0){
            GameObject temporary_Rigidbody2D;
            temporary_Rigidbody2D = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation);
            ammoAmount--;
            AmmoCounterSliderUpdate(ammoAmount);
        }
            return true ? ammoAmount > 0 : false;
    }
    //TODO Adicionar um temporizador de tiro e uma quantidade de munição
    
    private void AmmoCounterSliderUpdate(int ammo){
        ammoSlider.value = ammo;
    }
}
