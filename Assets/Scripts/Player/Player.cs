using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> spots;
    public Animation fade;
    public AnimationClip fadeInOut;

    public int currentIndexPosition;

    public static Player instance;

    Ray ray;
    RaycastHit hit;

    private void Start() 
    {
        instance = this;
    }

    void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
            return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonUp(0))
            {
                fade.Play("FadeInOut");
                if (hit.collider.CompareTag("Door"))
                {
                    currentIndexPosition = int.Parse(hit.collider.name);
                    StartCoroutine(ChangingPosition(currentIndexPosition));
                }

                if (hit.collider.CompareTag("Person"))
                {
                    hit.collider.GetComponent<DialogueTrigger>().StartDialogue();
                    StartCoroutine(GoTalkToCharacter(hit.transform.GetChild(0).transform));
                }
            }
        }
    }

    private IEnumerator ChangingPosition(int index)
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = spots[index].position;
    }

    private IEnumerator GoTalkToCharacter(Transform characterPosition)
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = characterPosition.position;
    }

    public void GoBackToPosition()
    {
        fade.Play("FadeInOut");
        StartCoroutine(ChangingPosition(currentIndexPosition));
    }
}
