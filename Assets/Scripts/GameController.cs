using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 3;
    [SerializeField] private GameObject _bullet_Spawn_Point;
    [SerializeField] private GameObject _bullet;    
    private float _timeToReload = 2;
    
    
    public Slider ammoSlider;
    public int ammoMax = 3;
    public float fillAmount = 0.1f;
    public float timeToReload = 2f;
    
    
    
    void Start(){
        AmmoCounterSliderUpdate(_ammoAmount);
        _timeToReload = timeToReload;
    }
    
    void Update(){
        AmmoRefill();
    }
    
    public bool FiredBullet(){
        if (_ammoAmount > 0){
            GameObject temporary_Rigidbody2D;
            temporary_Rigidbody2D = Instantiate(_bullet, _bullet_Spawn_Point.transform.position, _bullet_Spawn_Point.transform.rotation);
            _ammoAmount--;
            AmmoCounterSliderUpdate(_ammoAmount);
            
        }
            return AmmoAmountValidator();
    }    
    
    private bool AmmoAmountValidator(){
        return false ? _ammoAmount <= 0 : true;
    }
    
    private void AmmoCounterSliderUpdate(int ammo){
        ammoSlider.value = ammo;
        SliderColorFeedbackScript.SliderColorUpdater(ammo);
    }
    
    private void AmmoRefill(){
        if(timeToReload > 0 && _ammoAmount < ammoMax){
            timeToReload -= Time.deltaTime;
            if(timeToReload <= 0){
                _ammoAmount++;
                AmmoCounterSliderUpdate(_ammoAmount);
                timeToReload = _timeToReload;
            }
        }
    }
    
    private void EnemySpawn(){
        //TODO Criar mecanica para spawnar inimigos neste script e tambem evoluir na dificuldade. 2 tipos de inimigos (sniper e bomber)
        //Sniper - Fica fugindo do jogador e atirando de longe
        //Bomber - Corre até o jogador e explode
        //Spawnar os inimigos em ondas que aumentam a dificuldade com o tempo. Posso eliminar o reload automatico de munição e adicionar algo que o jogador precisa coletar, ou seja, vai precisar se posicionar corretamente e alinhar seus tiros.
    }
}
