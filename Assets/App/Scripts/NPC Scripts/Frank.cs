using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : NPC
{

    string[][] speeches;
    int[] reqf;
    int[] reqq;
    int speechIndex;

    void setSpeech(int ind, string str, int reqf1, int reqq1) {
        speeches[ind] = new string[1];
        speeches[ind][0] = str;
        reqf[ind] = reqf1; reqq[ind] = reqq1;
    }

    // Start is called before the first frame update
    void Start() {
        speeches = new string[13][];
        reqf = new int[13];
        reqq = new int[13];

        setSpeech(0, "Hi! I’m Frank. Once my bakery is rebuilt, you can check out my selection!", 1, 0);
        setSpeech(1, "Do you know how to fix a bakery?", 2, 0);
        setSpeech(2, "What the shell am I supposed to do now?", 2, 0);

        setSpeech(3, "Have you met Yvonne? I hear she’s clawstrophobic.", 3, 0);
        setSpeech(4, "Hey, how’s it going?", 3, 0);
        setSpeech(5, "Why are you wearing a scarf?", 3, 0);

        setSpeech(6, "Hey! Still rocking the scarf I see.", 4, 0);
        setSpeech(7, "Chad used to be a celebrity. A real star.", 4, 0);
        setSpeech(8, "Leo scares me.", 4, 0);

        setSpeech(9, "Yvonne asked me who was the second best fox in town after you. But you’re the only one, so I was out of Fox’ to give.", 5, 0);
        setSpeech(10, "You can have a friends and family discount, friend!", 5, 0);
        setSpeech(11, "You should call me, I just got a new shell phone!", 5, 0);

        setSpeech(12, "What can I get for ya?", 0, 0);

        speechIndex = 0;

    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnMouseOver() {

        if (Input.GetMouseButtonDown(1)) {

            CurrentQuest pquest = GameObject.FindGameObjectWithTag("Player").GetComponent<CurrentQuest>();
            Integrity Franks = GameObject.Find("Frank's").GetComponent<Integrity>();
            Integrity Karries = GameObject.Find("Karrie's").GetComponent<Integrity>();
            Integrity Chads = GameObject.Find("Chad's").GetComponent<Integrity>();
            Inventory pinv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

            if (friendship == 2 && Franks.status == 1) {
                friendship++;
            }

            //Check triggers
            if (pquest.quest_num == 0 && Franks.status > 0 &&
            Karries.status > 0 && pquest.quests[1].on_objective < pquest.quests[1].num_objectives) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "Hey! I have a cake waiting in the oven, so I can't leave right now...";
                mySpeech[1] = "Can you go pick up some cocoa beans from Karrie for me?";
                trigger.dialogue.sentences = mySpeech;
                pquest.quest_num = 1;

            } else if (pquest.quest_num == 1 && pquest.quests[1].on_objective == 1) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "You got the beans? How shell I ever repay you?";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                friendship++;
                Chads.status = 0;
                Karries.status = 0;

            } else if (pquest.quest_num == 5 && pquest.quests[1].on_objective == 2) {
                string[] mySpeech = new string[1];
                if (pinv.coins >= 10) {
                    mySpeech[0] = "Here's one loaf of bread for 10 coins!";
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 5;
                    pinv.coins -= 10;
                } else {
                    mySpeech[0] = "Fresh bread today, costs 10 coins!";
                }
                
                trigger.dialogue.sentences = mySpeech;

            } else {

                //Get the right dialogue
                int num = 0;
                int[] choices = new int[10];

                for (int i = 0; i < speeches.Length; i++) {
                    if ((friendship == reqf[i])) {
                        choices[num] = i;
                        num++;
                    }
                }

                int speechNum = choices[speechIndex % num];
                trigger.dialogue.sentences = speeches[speechNum];
            }

            speechIndex++;
            trigger.TriggerDialogue();

            if(friendship == 1) {
                friendship++;
            }

            return;
        }

    }
}
