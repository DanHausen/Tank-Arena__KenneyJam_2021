using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int _ammoMax = 3;
    private float _timeToReload;
    
    public Image image;
    public float timeToReload = 2f;
    public Slider ammoSlider;
    
    void Start(){
        AmmoCounterSliderUpdate(PlayerMovement._ammoAmount);
        _timeToReload = timeToReload;
        image = image.GetComponent<Image>();
    }
    
    void Update(){
        AmmoRefill();
    }
    
    private bool AmmoAmountValidator(){
        return false ? PlayerMovement._ammoAmount <= 0 : true;
    }
    
    public void AmmoCounterSliderUpdate(int ammo){
        ammoSlider.value = ammo;
        SliderColorUpdater(ammo);
    }
    
    private void AmmoRefill(){
        if(timeToReload > 0 && PlayerMovement._ammoAmount < _ammoMax){
            AmmoCounterSliderUpdate(PlayerMovement._ammoAmount);            
            timeToReload -= Time.deltaTime;
            if(timeToReload <= 0){
                PlayerMovement._ammoAmount++;
                timeToReload = _timeToReload;
            }
        }
    }
    
    private void EnemySpawn(){
        //TODO 3 Criar mecanica para spawnar inimigos. 2 tipos de inimigos (sniper e bomber)
            //Sniper - Fica fugindo do jogador e atirando de longe
            //Bomber - Corre até o jogador e explode
    }
    
    private void SliderColorUpdater(float ammo){
        switch(ammo){
            case 0:
                image.color = Color.red;
                break;
            case 1:
                image.color = Color.red;
                break;
            case 2:
                image.color = Color.yellow;
                break;
            case 3:
                image.color = Color.green;
                break;
        }
    }
    
    private void PauseMenu(){
        //TODO 2 Criar menu principal e de pausa
        //TODO 4 habilitar reload automatico(arcademode) ou munição para coletar(tankmode) no menu
    }
        
    //TODO 5 Alterar tipo de reload baseado na escolha do jogador
    //TODO 7 adicionar sons
    
}