using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public DialogueNodeAsset BioDialogue;
    public DialogueNodeAsset SpawnDialogue;
    public DialogueNodeAsset MidrunDialogue;
    public DialogueNodeAsset AtForkDialogue;
    public DialogueNodeAsset DieDialogue;
    public DialogueNodeAsset LoveDialogue;

    public DialogueNodeAsset GetDialogueNodeForType(DialogueNodeAsset.DialogueType DialogueType) {
        DialogueNodeAsset dialogueNode = null;
        switch (DialogueType) {
            case DialogueNodeAsset.DialogueType.Bio:
                dialogueNode = BioDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Spawn:
                dialogueNode = SpawnDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Midrun:
                dialogueNode = MidrunDialogue;
            break;
            case DialogueNodeAsset.DialogueType.AtFork:
                dialogueNode = AtForkDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Die:
                dialogueNode = DieDialogue;
            break;
            case DialogueNodeAsset.DialogueType.Love:
                dialogueNode = LoveDialogue;
            break;
            default:
                throw new System.Exception("Unimplemented type" + DialogueType);
        }
        return dialogueNode;
    }
}
