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

        foreach(NPC npc in NPCController.NPCs.Values){

            npcDistances.Add(npc.name, 0);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(NPC npc in NPCController.NPCs.Values){

            float playerToNPCDistance = (transform.position - npc.transform.position).magnitude;
            npcDistances[npc.name] = playerToNPCDistance;

            //Debug.Log(npc.name + " " + playerToNPCDistance);

        }
    }
}
