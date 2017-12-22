using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour {

    public MasterManager masterManager;
    
    public void ResumeGame()
    {
        masterManager.ResumeGame();
    }
}
