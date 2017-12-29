using UnityEngine;

public class PlayAgainButton : MonoBehaviour {

    public MasterManager masterManager;

    public void ResetGame()
    {
        masterManager.ResetGame();
    }
}
