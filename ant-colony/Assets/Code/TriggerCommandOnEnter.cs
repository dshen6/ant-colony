using System.Collections.Generic;
using UnityEngine;

public class TriggerCommandOnEnter : MonoBehaviour
{
    const float TRIGGER_THRESHOLD = 1;

    public List<Command> commands = new List<Command>();

    public bool isRepeatableTrigger = true;

    public void OnTriggerEnter(Collider other) {

        // If the trigger is not repeatable then we stop here.
        if (!isRepeatableTrigger) {return;}

        PlayerController player = other.gameObject.GetComponent<PlayerController>();;
        commands.ForEach(c => CommandManager.Instance.addCommand(c));
        // player.Die();
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, TRIGGER_THRESHOLD);
    }
}
