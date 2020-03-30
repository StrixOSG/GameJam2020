using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karrie : NPC {

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
        speeches = new string[11][];
        reqf = new int[11];
        reqq = new int[11];

        setSpeech(0, "Hey Darlin’, I’m Karrie. Come stop by my shop some time!", 1, 0);

        setSpeech(1, "Yvonne really loves christmas… I wonder why?", 2, 0);
        setSpeech(2, "Leo said I could pay him and he’d protect my shop…", 2, 0);
        setSpeech(3, "Does Leo see gullible people as targets? Get it? Seagull.", 2, 0);

        setSpeech(4, "Leo destroyed my shop… Can you help rebuild it?", 3, 0);

        setSpeech(5, "What’s the word again?", 4, 0);
        setSpeech(6, "Yvonne is in LOVE with Santa… I wonder why?", 4, 0);
        setSpeech(7, "Did Yvonne seem a little crabby to you?", 4, 0);

        setSpeech(8, "I finally figured out why Yvonne likes Christmas.", 5, 0);
        setSpeech(9, "You’re so sweet, I’d pick you up on the beach!", 5, 0);
        setSpeech(10, "I'm still craving those chips...", 5, 0);

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

            if (friendship == 1) {
                friendship++;
            }

            if (friendship == 3 && Karries.status == 1 && pquest.quests[1].on_objective >= pquest.quests[1].num_objectives) {
                friendship++;
            }

            //Check triggers
            if (pquest.quest_num == 1 && pquest.quests[1].on_objective == 0) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "You're picking up cocoa beans for Frank?";
                mySpeech[1] = "Here you go!";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 1;
                friendship++;

            } else if (pquest.quest_num == 2 && pquest.quests[2].on_objective == 0) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Aww that's sweet... maybe Chad's not so bad.";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();

            } else if (pquest.quest_num == 4 && pquest.quests[4].on_objective == 0) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "If you’re here for a protein bar, it’s not for sale. Unless…";
                mySpeech[1] = "I think Yvonne’s been napping in my shack. Can you go talk to her?";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();

            } else if (pquest.quest_num == 4 && pquest.quests[4].on_objective == 2) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Oh! Okay, great. Here’s the protein bar then.";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 4;

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

            return;
        }

    }
}
