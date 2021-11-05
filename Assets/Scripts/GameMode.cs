using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public enum GameModeState{ARCADE, TIME};
    public static GameModeState gameModeSelected;
    
    public void Arcade(){
        gameModeSelected = GameModeState.ARCADE;
    }
    
    public void Time(){
        gameModeSelected = GameModeState.TIME;        
    }
}
