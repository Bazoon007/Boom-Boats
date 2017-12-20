using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : BorderCollision {

    protected override void LogSailingBoat(string tag)
    {
        if (tag == "Diag" || tag == "RDiag")
        {
            Debug.Log("Sailing boat hits rock");
        }
    }
}
