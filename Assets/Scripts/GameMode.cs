using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public enum gameModeState{ARCADE, TIME};
    public static gameModeState gameModeSelected;
    
    public void Arcade(){
        gameModeSelected = gameModeState.ARCADE;
    }
    
    public void Time(){
        gameModeSelected = gameModeState.TIME;        
    }
}
