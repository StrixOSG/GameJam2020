using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter intro;
    public RectTransform canoe;
    public RectTransform player;
    public RectTransform titleCard;
    public GameObject title;
    public GameObject controllablePlayer;
    public GameObject questui;
    public GameObject invui;
    public GameObject songSelect;
    public Camera main;
    public Camera cutscene;
    public DialogueTrigger popup;
    public Sprite fox;
    private SpriteRenderer sprite;
    public float swimSpeed;
    private int state = 0;
    public int count = 0;
    public float waitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        main.enabled = false;
        cutscene.enabled = true;
        controllablePlayer.SetActive(false);
        invui.SetActive(false);
        questui.SetActive(false);
        title.SetActive(false);
        state = 0;
        popup.dialogue.portrait = fox;
        popup.dialogue.sentences = new string[2] { "A Gamejam game by Aiden, Jade, Kallin, Matt M., Matt H., and Shelby...",
                                                   "Welcome to the island!"};
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count < 500 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.1f * swimSpeed, 0, 0);
            player.position = player.position + new Vector3(0.1f * swimSpeed, 0, 0);
            count++;
        }
        else if (count < 800 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.1f * swimSpeed, -0.025f * swimSpeed, 0);
            player.position = player.position + new Vector3(0.1f * swimSpeed, -0.025f * swimSpeed, 0);
            count++;
        }
        else if (count < 950 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.1f * swimSpeed, 0, 0);
            player.position = player.position + new Vector3(0.1f * swimSpeed, 0, 0);
            count++;
        }
        else if (count < 1250 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.08f * swimSpeed, -0.06f * swimSpeed, 0);
            player.position = player.position + new Vector3(0.08f * swimSpeed, -0.06f * swimSpeed, 0);
            count++;
        }
        else if (count < 1400 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.1f * swimSpeed, 0.02f * swimSpeed, 0);
            player.position = player.position + new Vector3(0.1f * swimSpeed, 0.02f * swimSpeed, 0);
            count++;
        }
        else if (count < 1555 / swimSpeed && state == 0)
        {
            canoe.position = canoe.position + new Vector3(0.06f * swimSpeed, 0.1f * swimSpeed, 0);
            player.position = player.position + new Vector3(0.06f * swimSpeed, 0.1f * swimSpeed, 0);
            count++;
        }
        else if(count >= 1555 && state == 0 && !songSelect.activeSelf)
        {
            popup.TriggerDialogue();
            state = 90;
            count = 0;
        }
        else if(Input.anyKeyDown && state==90)
        {
            count++;
        }
        else if(count >= 1 && state==90)
        {
            state = 8;
        }
        else if(state == 8)
        {
            title.SetActive(true);
            sprite = title.GetComponent<SpriteRenderer>();
            sprite.color =new Color(255f,255f,255f, 0);

            state = 1;
            count = 0;
            //THIS IS FMOD STUFF PLEASE DO NOT CHANGE
            intro.SetParameter("Get Off The Boat", 1);
        }
        if (waitTime < 200 && state == 1)
        {
            sprite.color = new Color(255, 255, 255, waitTime / 200f);
            waitTime++;
            titleCard.position += new Vector3(0, 0.04f, 0);
        }
        else if (state == 1)
        {
            state = 2;
        }
        if(state == 2 && count < 150)
        {
            count++;
        }
        else if (state == 2)
        {
            state = 3;
            count = 0;
            waitTime = 200;
        }
        if(state == 3 && waitTime > 1)
        {
            sprite.color = new Color(255, 255, 255, sprite.color.a - 0.03f);
            waitTime--;
            titleCard.position += new Vector3(0, 0.05f, 0);
        }
        else if(state == 3)
        {
            sprite.color = new Color(255, 255, 255, 0f);
            player.position = new Vector3(1000000, 1000000, -100000);
            cutscene.enabled = false;
            main.enabled = true;
            controllablePlayer.SetActive(true);
            invui.SetActive(true);
            questui.SetActive(true);
        }

    }
}
