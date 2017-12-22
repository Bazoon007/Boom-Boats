using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour {

        public void ChangeMuteSettings()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
