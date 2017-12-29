using UnityEngine;

public class StartGameButton : MonoBehaviour {

    public MasterManager masterManager;

    public void StartGame()
    {
        masterManager.StartGame();
    }
}
