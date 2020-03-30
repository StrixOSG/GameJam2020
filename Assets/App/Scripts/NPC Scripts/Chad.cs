using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chad : NPC {

    void setSpeech(int ind, string str, int reqf1, int reqq1) {
        speeches[ind] = new string[1];
        speeches[ind][0] = str;
        reqf[ind] = reqf1; reqq[ind] = reqq1;
    }

    // Start is called before the first frame update
    void Start() {

        name = "Chad";
        NPCController.NPCs.Add(name, this);

        speeches = new string[11][];
        reqf = new int[11];
        reqq = new int[11];

        setSpeech(0, "I'm Chad, but you can call me Chad. Good to meet you, bro.", 1, 0);

        setSpeech(1, "One... Two... Three...", 2, 0);
        setSpeech(2, "*Huff*", 2, 0);
        setSpeech(3, "I used to be a celebrity, but now I’m just a star, bro.", 2, 0);

        setSpeech(4, "Leo doesn’t want any visitors.", 3, 0);

        setSpeech(5, "Rebuilding my house was a real bro move, bro.", 4, 0);
        setSpeech(6, "Working out at night is nice. The stars make such a nice view.", 4, 0);
        setSpeech(7, "Leo’s just misunderstood, bro. You vibin’?", 4, 0);

        setSpeech(8, "Wanna be workout buddies, bro?", 5, 0);
        setSpeech(9, "Broooo, what’s up?", 5, 0);
        setSpeech(10, "If we workout together, you gotta get rid of that scarf. But it looks good bro.", 5, 0);

        speechIndex = 0;

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseOver() {

        if (Input.GetMouseButtonDown(1)) {

            CurrentQuest pquest = GameObject.FindGameObjectWithTag("Player").GetComponent<CurrentQuest>();
            Integrity Franks = GameObject.Find("Frank's").GetComponent<Integrity>();
            Integrity Yvonnes = GameObject.Find("Yvonne's").GetComponent<Integrity>();
            Integrity Chads = GameObject.Find("Chad's").GetComponent<Integrity>();
            Integrity Karries = GameObject.Find("Karrie's").GetComponent<Integrity>();

            if (friendship == 3 && Chads.status == 1) {
                friendship++;
            }

            //Check triggers
            if (pquest.quest_num == 2 && pquest.quests[2].on_objective == 1) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Karrie? That bird must be high… flying high! Not rad, bro!";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                pquest.Progress();

            } else if (pquest.quest_num == 0 && Yvonnes.status > 0 && Chads.status > 0 &&
            Karries.status > 0 && pquest.quests[4].on_objective < pquest.quests[4].num_objectives) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "Hey bro, I heard Karrie found a protein bar!";
                mySpeech[1] = "Can you go buy it for me?";
                trigger.dialogue.sentences = mySpeech;
                pquest.quest_num = 4;

            } else if (pquest.quest_num == 4 && pquest.quests[4].on_objective == 3) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "That took a while bro, everything okay?";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                friendship = 5;

            } else if (pquest.quest_num == 5 && pquest.quests[5].on_objective == 0) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "I’d love to help Yvonne workout! Can you let her know?";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();

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

            if (friendship == 1) {
                friendship++;
            }

            return;
        }

    }
}
