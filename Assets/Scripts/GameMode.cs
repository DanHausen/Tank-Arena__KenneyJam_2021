using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private enum _GameModeState{ARCADE, TIME};
    public static GameModeState gameModeSelected;
    
    public void Arcade(){
        gameModeSelected = _GameModeState.ARCADE;
    }
    
    public void Time(){
        gameModeSelected = _GameModeState.TIME;        
    }
}
