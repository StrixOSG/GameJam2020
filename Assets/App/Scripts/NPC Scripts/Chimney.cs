using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    
    // Update is called once per frame
    void OnMouseOver() {

        if (Input.GetMouseButtonDown(1)) {

            CurrentQuest pquest = GameObject.FindGameObjectWithTag("Player").GetComponent<CurrentQuest>();

            //Check triggers
            if (pquest.quest_num == 6 && pquest.quests[6].on_objective == 1) {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                
                //Set all NPCs friendship level to 5
                foreach(NPC npc in NPCController.NPCs.Values){

                    npc.friendship = 5;

                }

            }

            return;
        }

    }
}
