using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicControl : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter main;
    public PlayerToNPCDistance distance;

    private float multiplier = 3.5f;

    // Update is called once per frame
    void Update()
    {

        if(distance.isActiveAndEnabled){

            //yvonne        
            if(distance.npcDistances["Yvonne"] * multiplier >= 30)
            {
                main.SetParameter("Yvonne Distance", 30f);
            }
            else
            {
                main.SetParameter("Yvonne Distance", distance.npcDistances["Yvonne"] * multiplier);
            }
            //chad        
            if(distance.npcDistances["Chad"] * multiplier >= 30)
            {
                main.SetParameter("Chad Distance", 30f);
            }
            else
            {
                main.SetParameter("Chad Distance", distance.npcDistances["Chad"] * multiplier);
            }     

            //karrie
            if(distance.npcDistances["Karrie"] * multiplier >= 30)
            {
                main.SetParameter("Karrie Distance", 30f);
            }
            else
            {
                main.SetParameter("Karrie Distance", distance.npcDistances["Karrie"] * multiplier);
            }
            //frank
            if(distance.npcDistances["Frank"] * multiplier >= 30)
            {
                main.SetParameter("Frank Distance", 30f);
            }
            else
            {
                main.SetParameter("Frank Distance", distance.npcDistances["Frank"] * multiplier);
            }
            //leo
            if(distance.npcDistances["Leo"] * multiplier >= 30)
            {
                main.SetParameter("Leo Distance", 30f);
            }
            else
            {
                main.SetParameter("Leo Distance", distance.npcDistances["Leo"] * multiplier);
            }

            foreach(NPC npc in NPCController.NPCs.Values){

                int friendship = npc.friendship;

                if(friendship > 3){

                    main.SetParameter(npc.name + " Friend State", friendship - 3);

                }

            }

        }

    }
}
