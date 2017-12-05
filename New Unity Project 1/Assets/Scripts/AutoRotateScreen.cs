using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.autorotateToLandscapeLeft = true;

        Screen.orientation = ScreenOrientation.Landscape;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
