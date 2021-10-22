using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int _ammoMax = 3;
    private float _timeToReload = 2f;
    private static Image _image;    
    
    public float timeToReload = 2f;
    public Slider ammoSlider;
    
    void Start(){
        AmmoCounterSliderUpdate(PlayerMovement._ammoAmount);
        _timeToReload = timeToReload;
        _image = gameObject.GetComponentInChildren<Image>();
        
    }
    
    void Update(){
        AmmoRefill();
    }
    
    private bool AmmoAmountValidator(){
        return false ? PlayerMovement._ammoAmount <= 0 : true;
    }
    
    public void AmmoCounterSliderUpdate(float ammo){
        ammoSlider.value = ammo;
        SliderColorUpdater(ammo);
    }
    
    private void AmmoRefill(){
        if(timeToReload > 0 && PlayerMovement._ammoAmount < _ammoMax){
            timeToReload -= Time.deltaTime;
            if(timeToReload <= 0){
                PlayerMovement._ammoAmount++;
                AmmoCounterSliderUpdate(PlayerMovement._ammoAmount);
                timeToReload = _timeToReload;
            }
        }
    }
    
    private void EnemySpawn(){
        //TODO Criar mecanica para spawnar inimigos neste script e tambem evoluir na dificuldade. 2 tipos de inimigos (sniper e bomber)
        //Sniper - Fica fugindo do jogador e atirando de longe
        //Bomber - Corre até o jogador e explode
        
        //TODO Adicionar animação de explosão do kit do Kenney. Removendo as particulas que inseri.
        
        //TODO Criar mecanica para IA dos inimigos
        
        //TODO Criar menu principal e de pausa
        
        //TODO eliminar o reload automatico de munição e adicionar algo que o jogador precisa coletar, ou seja, vai precisar se posicionar corretamente e alinhar seus tiros.
    }    
    
    private void SliderColorUpdater(float ammo){
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
