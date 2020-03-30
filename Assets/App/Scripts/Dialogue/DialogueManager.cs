using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portrait;
    public Image textBox;
    public Confirm confirm;
    public Deny deny;
    private bool disabled;
    private bool canClick;
    public int decision; //0 is undecided, 1 is accept, 2 is deny.

    private Queue<string> sentences;

    /// <summary>
    /// DON'T Call this directly.  Call through DialogueTrigger class.
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue (Dialogue dialogue)
    {
        if(!disabled)
        {
            throw (new System.ArgumentException("Dialogue tried to be called while still in dialogue!", "original"));
        }
        canClick = true;
        EnableTextBox(dialogue.portrait);
        nameText.text = dialogue.npcName;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        disabled = false;
    }

    /// <summary>
    /// Displayes the next sentence in the dialogue.
    /// </summary>
    public void DisplayNextSentence()
    {
        string tempSent = sentences.Dequeue();
        if (tempSent == "choose")
        {
            decision = 0;
            canClick = false;
            confirm.GetComponent<RectTransform>().position = confirm.GetComponent<RectTransform>().position - new Vector3(0, 10000);
            deny.GetComponent<RectTransform>().position = deny.GetComponent<RectTransform>().position - new Vector3(0, 10000);
            return;
        }
        dialogueText.text = tempSent;
        if (sentences.Count+1 == 0)
        {
            DisableTextBox();
            return;
        }
 
    }

    /// <summary>
    /// Shows the dialogue box on screen.
    /// </summary>
    /// <param name="dialoguePortrait"></param>
    public void EnableTextBox(Sprite dialoguePortrait)
    {
        textBox.GetComponent<RectTransform>().position = textBox.GetComponent<RectTransform>().position - new Vector3(0,10000);
        portrait.sprite = dialoguePortrait;
    }

    /// <summary>
    /// Hides the dialogue box from screen.
    /// </summary>
    public void DisableTextBox()
    {
        textBox.GetComponent<RectTransform>().position = textBox.GetComponent<RectTransform>().position + new Vector3(0, 10000);
        sentences.Clear();
        disabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        confirm.GetComponent<RectTransform>().position = confirm.GetComponent<RectTransform>().position + new Vector3(0, 10000);
        deny.GetComponent<RectTransform>().position = deny.GetComponent<RectTransform>().position + new Vector3(0, 10000);
        sentences = new Queue<string>();
        DisableTextBox();
    }

    void Update()
    {
        if(confirm.finished)
        {
            confirm.GetComponent<RectTransform>().position = confirm.GetComponent<RectTransform>().position + new Vector3(0, 10000);
            deny.GetComponent<RectTransform>().position = deny.GetComponent<RectTransform>().position + new Vector3(0, 10000);
            decision = 1;
            confirm.finished = false;
            canClick = true;
            DisableTextBox();
        }
        if (deny.finished)
        {
            confirm.GetComponent<RectTransform>().position = confirm.GetComponent<RectTransform>().position + new Vector3(0, 10000);
            deny.GetComponent<RectTransform>().position = deny.GetComponent<RectTransform>().position + new Vector3(0, 10000);
            decision = 2;
            deny.finished = false;
            canClick = true;
            DisableTextBox();
        }
        if (Input.anyKeyDown && sentences.Count != 0 && !disabled && canClick)
        {
            DisplayNextSentence();
        }
        else if (Input.anyKeyDown && sentences.Count == 0 && !disabled && canClick)
        {
            DisableTextBox();
        }
    }
}
