using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset dialogue;

    public void StartDialogue()
    {
        DialogueManager.GetInstance().EnterDialogueMode(dialogue);
    }
}
