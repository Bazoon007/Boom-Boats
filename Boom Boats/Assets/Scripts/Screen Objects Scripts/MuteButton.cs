using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    public Sprite OnImage;
    public Sprite OffImage;
    public Button muteButton;
    public MasterManager masterManager;

    public void ChangeMuteSettings()
    {
            AudioListener.pause = !AudioListener.pause;
            masterManager.changeAllMuteButtons(AudioListener.pause);
    }

    public void ChangeMuteButtonImage(bool isPaused)
    {
        if (isPaused)
        {
            muteButton.image.sprite = OffImage;
        }
        else
        {
            muteButton.image.sprite = OnImage;
        }
    }
}
