using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 3;
    [SerializeField] private Text scorePointsText;    
    [SerializeField] private GameObject bullet_Spawn_Point;
    [SerializeField] private GameObject bullet;    
    
    private bool fireTimerBlocked = false;
    
    public Slider ammoSlider;
    public int ammoMax = 3;
    public float fillAmount = 0.1f;
    
    //TODO Criar mecanica para spawnar inimigos neste script e tambem evoluir na dificuldade
    //TODO Aqui tambem vai o temporizador e leaderboard
    //TODO seria bacana adicionar power ups
    
    void Start(){
        AmmoCounterSliderUpdate(ammoAmount);
    }
    
    void Update(){
        AmmoRefill();
    }
    
    public bool FiredBullet(){
        if (ammoAmount > 0){
            GameObject temporary_Rigidbody2D;
            temporary_Rigidbody2D = Instantiate(bullet, bullet_Spawn_Point.transform.position, bullet_Spawn_Point.transform.rotation);
            ammoAmount--;
            AmmoCounterSliderUpdate(ammoAmount);
        }
            return AmmoTimmerBlocker();
    }
    
    private void AmmoCounterSliderUpdate(int ammo){
        ammoSlider.value = ammo;
    }
    
    //TODO Adicionar um temporizador de tiro    
    private bool AmmoTimmerBlocker(){
        return false ? ammoAmount <= 0 : true;
    }
    
    private void AmmoRefill(){
        if(ammoAmount < ammoMax){//TODO Não está funcionando
            ammoSlider.value += fillAmount * Time.deltaTime;
        }
        else{
            fireTimerBlocked = AmmoTimmerBlocker();
        }
    }
}
