using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : NPC {

    void setSpeech(int ind, string str, int reqf1, int reqq1) {
        speeches[ind] = new string[1];
        speeches[ind][0] = str;
        reqf[ind] = reqf1; reqq[ind] = reqq1;
    }

    // Start is called before the first frame update
    void Start() {

        name = "Leo";
        NPCController.NPCs.Add(name, this);

        speeches = new string[13][];
        reqf = new int[13];
        reqq = new int[13];

        setSpeech(0, "I’m Leo, don’t get in my way.", 1, 0);

        setSpeech(1, "I don’t like this island.", 2, 0);
        setSpeech(2, "Why is Karrie so ornery?", 2, 0);
        setSpeech(3, "Who are you again?", 2, 0);

        setSpeech(4, "Go away.", 3, 0);
        setSpeech(5, "I’m not the one destroying everything.", 3, 0);
        setSpeech(6, "Who are you again?", 3, 0);

        setSpeech(7, "You’re safe... if you stay out of my way.", 4, 0);
        setSpeech(8, "Are you here to pay me money…?", 4, 0);
        setSpeech(9, "Is Karrie saying bad things about me? Good.", 4, 0);

        setSpeech(10, "Everyone can grow from their mistakes.", 5, 0);
        setSpeech(11, "I’m A rabbit. If you walk 8 miles up the road, you’ll find B rabbit.", 5, 0);
        setSpeech(12, "Karrie still gets on my nerves sometimes.", 5, 0);

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
            GameObject Karrie = GameObject.Find("Karrie");

            if (friendship == 3 && Chads.status == 1) {
                friendship++;
            }

            //Check triggers
            if (pquest.quest_num == 0 && Karries.status > 0 &&
            pquest.quests[2].on_objective >= pquest.quests[2].num_objectives && pquest.quests[3].on_objective < pquest.quests[3].num_objectives) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "I don’t like Karrie; but I hear she just found some carrots.";
                mySpeech[1] = "Can you pick some up for me?";
                trigger.dialogue.sentences = mySpeech;
                pquest.quest_num = 3;
                float new_y = Karrie.transform.position.y + 10000.0f;
                Karrie.transform.position = new Vector3(Karrie.transform.position.x, new_y, Karrie.transform.position.z);

            } else if (pquest.quest_num == 3 && pquest.quests[3].on_objective == 2) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "They’re sandy…";
                mySpeech[1] = "Thanks anyways, I guess.";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                friendship++;
                pquest.Progress();
                pquest.quest_num = 0;

            } else if (pquest.quest_num == 0 && Karries.status > 0 &&
                pquest.quests[2].on_objective >= pquest.quests[2].num_objectives &&
                pquest.quests[3].on_objective >= pquest.quests[3].num_objectives &&
                pquest.quests[4].on_objective >= pquest.quests[4].num_objectives &&
                pquest.quests[5].on_objective >= pquest.quests[5].num_objectives &&
            pquest.quests[6].on_objective < pquest.quests[6].num_objectives) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Don’t ask why, but I need you to distribute these straws on the beach";
                trigger.dialogue.sentences = mySpeech;
                pquest.quest_num = 6;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 6;

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
