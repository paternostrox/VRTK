using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    static float textSpeed = .1f;
    [SerializeField]
    TMP_Text UIText;
    [SerializeField]
    GameObject dialoguePanel;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void Display(string text)
    {
        float exibitionTime = text.Length * textSpeed;
        UIText.text = text;
        dialoguePanel.SetActive(true);
    }

    IEnumerator TempDialogue(float exibitionTime)
    {
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(exibitionTime);
        dialoguePanel.SetActive(false);
    }
}
