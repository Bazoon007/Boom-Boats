using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour {

    public MasterManager masterManager;

    public void StartGame()
    {
        masterManager.StartGame();
    }
}
