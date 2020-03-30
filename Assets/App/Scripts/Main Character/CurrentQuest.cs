using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentQuest : MonoBehaviour
{

    public int quest_num = 7;
    public int ob_num = 0;
    public Quest[] quests = new Quest[8];
    Inventory inventory;

    /* o_act - o_info
     * 0 = Nothing
     * 1 = Talk to
     *      1 = Leo
     *      2 = Frank
     *      3 = Chad
     *      4 = Karrie
     *      5 = Yvonne
     * 2 = Fill Inventory Special
     *      Special item ID
     * 3 = Empty Inventory Special
     * 4 = Go to
     *      0 = Beach
     *      1 = Forest
     */

    // Start is called before the first frame update
    void Start() {
        //Define quests
        quests[0] = new Quest("No Quest!", 1);
        quests[0].objectives[0] = "Explore the island!";

        quests[1] = new Quest("Turtle's Treats", 2);
        quests[1].objectives[0] = "Buy cocoa beans from Karrie.";
        quests[1].o_act[0] = 2;
        quests[1].o_info[0] = 1;
        quests[1].objectives[1] = "Deliver cocoa beans to Frank.";
        quests[1].o_act[1] = 3;

        quests[2] = new Quest("Matchmaker", 2);
        quests[2].objectives[0] = "Deliver gift to Karrie.";
        quests[2].o_act[0] = 1;
        quests[2].o_info[0] = 4;
        quests[2].objectives[1] = "Deliver gift to Chad.";
        quests[2].o_act[1] = 3;

        quests[3] = new Quest("Karrie's Karrots", 3);
        quests[3].objectives[0] = "Buy carrots from Karrie.";
        quests[3].o_act[0] = 4;
        quests[3].o_info[0] = 0;
        quests[3].objectives[1] = "Find Karrie.";
        quests[3].o_act[1] = 2;
        quests[3].o_info[1] = 3;
        quests[3].objectives[2] = "Deliver carrots to Leo.";
        quests[3].o_act[2] = 3;

        quests[4] = new Quest("Bars for Bros", 4);
        quests[4].objectives[0] = "Buy protein bar from Karrie.";
        quests[4].o_act[0] = 2;
        quests[4].o_info[0] = 4;
        quests[4].objectives[1] = "Talk to Yvonne.";
        quests[4].o_act[1] = 1;
        quests[4].o_info[1] = 5;
        quests[4].objectives[2] = "Talk to Karrie.";
        quests[4].o_act[2] = 1;
        quests[4].o_info[2] = 4;
        quests[4].objectives[3] = "Deliver protein bar to Chad.";
        quests[4].o_act[3] = 3;

        quests[5] = new Quest("Crab Crunches", 4);
        quests[5].objectives[0] = "Talk to Chad.";
        quests[5].o_act[0] = 1;
        quests[5].o_info[0] = 3;
        quests[5].objectives[1] = "Talk to Yvonne.";
        quests[5].o_act[1] = 1;
        quests[5].o_info[1] = 5;
        quests[5].objectives[2] = "Buy bread from Frank.";
        quests[5].o_act[2] = 2;
        quests[5].o_info[2] = 5;
        quests[5].objectives[3] = "Deliver bread to Yvonne.";
        quests[5].o_act[2] = 3;

        quests[6] = new Quest("De-straw-ying the Beach", 2);
        quests[6].objectives[0] = "Go to the beach.";
        quests[6].o_act[0] = 4;
        quests[6].o_info[0] = 0;
        quests[6].objectives[1] = "Throw the straws in Yvonne's chimney.";
        quests[6].o_act[1] = 3;

        quests[7] = new Quest("Settling In", 1);
        quests[7].objectives[0] = "Rebuild your house for 100 logs.";
        quests[7].o_act[0] = 5;

        inventory = GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update() {
        ob_num = quests[quest_num].on_objective;

        //Cleared inventory progression
        if(quests[quest_num].o_act[ob_num] == 3 && inventory.special == 0) {
            Progress();
            return;
        }

        //Obtained item progression
        if(quests[quest_num].o_act[ob_num] == 2 && inventory.special == quests[quest_num].o_info[ob_num]) {
            Progress();
            return;
        }

        //Cleared inventory progression
        if (quests[quest_num].o_act[ob_num] == 4 && transform.position.x < 0.0f) {
            Progress();
            return;
        }

        //Build your house
        if (quests[quest_num].o_act[ob_num] == 5) {
            Integrity Yours = GameObject.Find("Yours").GetComponent<Integrity>();
            if (Yours.status == 1)
                Progress();
        }
    }

    public void Progress() {
        quests[quest_num].on_objective++;
        if (quests[quest_num].on_objective >= quests[quest_num].num_objectives) {
            quest_num = 0;
        }
    }
}