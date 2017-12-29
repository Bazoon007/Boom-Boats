using UnityEngine;

public class ResumeGameButton : MonoBehaviour {

    public MasterManager masterManager;
    
    public void ResumeGame()
    {
        masterManager.ResumeGame();
    }
}
