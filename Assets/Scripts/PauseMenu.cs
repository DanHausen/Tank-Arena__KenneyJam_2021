using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    public GameObject pauseMenuUI;    
    
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            PressPauseButton();
        }
    }
    
    public void PressPauseButton(){
        Debug.Log("PressPauseButton");
        if(gameIsPaused){
            ResumeGame();
        }
        else{
            PauseGame();
        }
    }
    
    private void ResumeGame(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    
    private void PauseGame(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
