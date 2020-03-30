using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToNPCDistance : MonoBehaviour
{

    public Dictionary<string, float> npcDistances;

    // Start is called before the first frame update
    void Start()
    {

        npcDistances = new Dictionary<string, float>();

        foreach(string npcName in NPCController.NPCNames){

            npcDistances.Add(npcName, 0);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject npc in GameObject.FindGameObjectsWithTag("NPC")){

            float playerToNPCDistance = (transform.position - npc.transform.position).magnitude;
            npcDistances[npc.name] = playerToNPCDistance;

            //Debug.Log(npc.name + " " + playerToNPCDistance);

        }
    }
}
