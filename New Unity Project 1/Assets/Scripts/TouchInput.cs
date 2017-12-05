using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;


    void Update()
    {

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    /*
                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    */
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    /*
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    */
                }
            }
            /*
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
            */
        }
    }
}
