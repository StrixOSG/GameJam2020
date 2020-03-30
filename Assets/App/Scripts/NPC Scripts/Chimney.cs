using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour
{
    
    // Update is called once per frame
    void OnMouseOver() {

        if (Input.GetMouseButtonDown(1)) {

            CurrentQuest pquest = GameObject.FindGameObjectWithTag("Player").GetComponent<CurrentQuest>();
            Frank frank = GameObject.Find("Frank").GetComponent<Frank>();
            Leo leo = GameObject.Find("Leo").GetComponent<Leo>();
            Yvonne yvonne = GameObject.Find("Yvonne").GetComponent<Yvonne>();
            Karrie karrie = GameObject.Find("Karrie").GetComponent<Karrie>();
            Chad chad = GameObject.Find("Chad").GetComponent<Chad>();

            //Check triggers
            if (pquest.quest_num == 6 && pquest.quests[6].on_objective == 1) {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().special = 0;
                frank.friendship = 5;
                leo.friendship = 5;
                yvonne.friendship = 5;
                karrie.friendship = 5;
                chad.friendship = 5;
            }

            return;
        }

    }
}
