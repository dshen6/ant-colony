using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    void Awake() {
         if (_instance == null){
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(DialogueNodeAsset.DialogueType DialogueType)
    {
        Speaker speaker = PlayerController.Instance.gameObject.GetComponent<Speaker>();
        Debug.Log("Starting conversation: ");
    }
}
