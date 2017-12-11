using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchInputMask;
    private RaycastHit hit;


    void Update()
    {

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                   
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                   
                }
            }
        }
    }
}
