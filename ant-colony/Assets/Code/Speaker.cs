using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public DialogueNodeAsset SpawnDialogue;
    public DialogueNodeAsset DieDialogue;
    public DialogueNodeAsset MidrunDialogue;
    public DialogueNodeAsset AtForkDialogue;
    public DialogueNodeAsset LoveDialogue;

    public DialogueNodeAsset GetDialogueNodeForType(DialogueNodeAsset.DialogueType DialogueType) {
        DialogueNodeAsset dialogueNode = null;
        switch (DialogueType) {
            case DialogueNodeAsset.DialogueType.Spawn:
                dialogueNode = SpawnDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Die:
                dialogueNode = DieDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Love:
                dialogueNode = LoveDialogue;
            break;
            case DialogueNodeAsset.DialogueType.AtFork:
                dialogueNode = LoveDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Midrun:
                dialogueNode = MidrunDialogue;
            break;
            default:
            
        }
        return dialogueNode;
    }
}
