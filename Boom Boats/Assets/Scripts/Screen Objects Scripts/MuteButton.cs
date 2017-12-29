using UnityEngine;

public class MuteButton : MonoBehaviour {

        public void ChangeMuteSettings()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
