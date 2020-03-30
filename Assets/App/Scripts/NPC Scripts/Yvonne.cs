using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yvonne: NPC {

    void setSpeech(int ind, string str, int reqf1, int reqq1) {
        speeches[ind] = new string[1];
        speeches[ind][0] = str;
        reqf[ind] = reqf1; reqq[ind] = reqq1;
    }

    // Start is called before the first frame update
    void Start() {

        name = "Yvonne";
        NPCController.NPCs.Add(name, this);

        speeches = new string[10][];
        reqf = new int[10];
        reqq = new int[10];

        setSpeech(0, "Hey Sweetie, I’m… uh… who are you again?", 1, 0);

        setSpeech(1, "I’m in a pinch! My house got destroyed!", 2, 0);

        setSpeech(2, "Yvonne loves christmas", 3, 0);
        setSpeech(3, "What was I doing again?", 3, 0);
        setSpeech(4, "Yvonne likes to hang christmas lights on her house.", 3, 0);

        setSpeech(5, "Karrie’s so pretty. She has a lot of clothes in her clawset.", 4, 0);
        setSpeech(6, "Yvonne loves this little town.", 4, 0);
        setSpeech(7, "What a handsome young fox you are!", 4, 0);

        setSpeech(8, "You’re so cute, let me pinch your cheeks!", 5, 0);
        setSpeech(9, "Who said Yvonne was crabby?", 5, 0);

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
            GameObject Karrie = GameObject.Find("Karrie");

            if (friendship == 2 && Yvonnes.status == 1) {
                friendship++;
            }

            //Check triggers
            if (pquest.quest_num == 0 && Yvonnes.status > 0 &&
            pquest.quests[1].on_objective >= pquest.quests[1].num_objectives &&
            pquest.quests[2].on_objective < pquest.quests[2].num_objectives) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "I think Karrie and Chad would make a cute couple.";
                mySpeech[1] = "Can you deliver these gifts to them? Say they're from eachother.";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 2;
                pquest.quest_num = 2;
                friendship++;

            } else if (pquest.quest_num == 3 && (pquest.quests[3].on_objective == 0 || pquest.quests[3].on_objective == 1)) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Not sure where Karrie went, but I found these in her shack where I was… napping.";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 3;
                pquest.quests[3].on_objective = 2;
                float new_y = Karrie.transform.position.y - 10000.0f;
                Karrie.transform.position = new Vector3(Karrie.transform.position.x, new_y, Karrie.transform.position.z);


            } else if (pquest.quest_num == 4 && pquest.quests[4].on_objective == 1) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "I thought Karrie knew I was napping there… can you tell her I’m sorry?";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();

            } else if (pquest.quest_num == 0 && Yvonnes.status > 0 && Chads.status > 0 &&
            pquest.quests[2].on_objective >= pquest.quests[2].num_objectives &&
            pquest.quests[5].on_objective < pquest.quests[5].num_objectives) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "I wish there was a seniors’ fitness program here.";
                mySpeech[1] = "Can you go ask Chad about that, dear?";
                trigger.dialogue.sentences = mySpeech;
                pquest.quest_num = 5;

            } else if (pquest.quest_num == 5 && pquest.quests[5].on_objective == 1) {
                string[] mySpeech = new string[2];
                mySpeech[0] = "That’s great dear! I’m too tired yet though...";
                mySpeech[1] = "Can you buy me some food from Frank?";
                trigger.dialogue.sentences = mySpeech;
                pquest.Progress();

            } else if (pquest.quest_num == 5 && pquest.quests[5].on_objective == 3) {
                string[] mySpeech = new string[1];
                mySpeech[0] = "Thanks sweetie, I’ll let you go about your business now.";
                trigger.dialogue.sentences = mySpeech;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                pquest.Progress();
                friendship++;

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

                int speechNum;

                speechNum = choices[speechIndex % num];

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
