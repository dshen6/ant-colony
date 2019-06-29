using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCommandOnEnter : MonoBehaviour
{
    const float TRIGGER_THRESHOLD = 1;

    // TODO: introduce command class to use for this
    //public List<Command> Commands;

    public bool isRepeatableTrigger = true;

    public void OnTriggerEnter(Collider other) {

        // If the trigger is not repeatable then we stop here.
        if (!isRepeatableTrigger) {return;}

        // TODO: validate gameobject is a playercontroller
        PlayerController player = (PlayerController) other.gameObject.GetComponent<MonoBehaviour>();
        player.Die();
    }
    

    // public void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position, TRIGGER_THRESHOLD);
    // }

    // public void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position, TRIGGER_THRESHOLD);
    // }
}
