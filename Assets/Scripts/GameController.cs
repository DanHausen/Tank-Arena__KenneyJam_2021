using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int _ammoMax = 3;
    private float _timeToReload = 2f;
    
    public float timeToReload = 2f;
    public Slider ammoSlider;
    
    void Start(){
        AmmoCounterSliderUpdate(PlayerMovement._ammoAmount);
        _timeToReload = timeToReload;
    }
    
    void Update(){
        AmmoRefill();
    }
    
    private bool AmmoAmountValidator(){
        return false ? PlayerMovement._ammoAmount <= 0 : true;
    }
    
    public void AmmoCounterSliderUpdate(int ammo){
        ammoSlider.value = ammo;
        SliderColorFeedbackScript.SliderColorUpdater(ammo);
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
}
