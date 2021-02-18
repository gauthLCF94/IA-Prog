using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform PlayerTransform;
 
    public Transform TeleportGoal;

    void OnTriggerEnter ()
    {
        Debug.Log("OnTriggerEnter");
        PlayerTransform.position = TeleportGoal.position;
    }

}
