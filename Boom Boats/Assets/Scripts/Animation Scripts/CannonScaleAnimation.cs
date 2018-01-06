using UnityEngine;

public class CannonScaleAnimation : MonoBehaviour {

	public void ActivateScaleAnimation()
    {
        GetComponent<Animation>().Play();
    }
}
