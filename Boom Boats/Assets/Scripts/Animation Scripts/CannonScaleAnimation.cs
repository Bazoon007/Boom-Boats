using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScaleAnimation : MonoBehaviour {

	public void ActivateScaleAnimation()
    {
        GetComponent<Animation>().Play();
        Debug.Log("Activate Animation");
    }
}
