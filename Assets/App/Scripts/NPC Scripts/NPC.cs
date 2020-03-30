using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Sprite Portrait;
    public DialogueTrigger trigger;
    public string name;
    public string[] speech;
    public int friendship; //1 to 5: meet, houseless, neutral, friendly, +friendly

    /// <summary>
    /// Moves the NPC down.
    /// </summary>
    public void moveUp(int time)
    {
        for (int i = 0; i < time; i++)
            transform.position = transform.position + new Vector3(0, 0.1f, 0) * time;
    }

    /// <summary>
    /// Moves the NPC down.
    /// </summary>
    public void moveDown(int time, float speed = 1)
    {
        for (int i = 0; i < time; i++)
            transform.position = transform.position + new Vector3(0, -0.01f, 0) * speed;
    }

    /// <summary>
    /// Moves the NPC left.
    /// </summary>
    public void moveLeft(int time)
    {
        for (int i = 0; i < time; i++)
            transform.position = transform.position + new Vector3(-0.1f, 0, 0) * time;
    }

    /// <summary>
    /// Moves the NPC right.
    /// </summary>
    public void moveRight(int time)
    {
        for (int i = 0; i < time; i++)
            transform.position = transform.position + new Vector3(0.1f, 0, 0) * time;
    }

    // Start is called before the first frame update
    void Start()
    {
        trigger.dialogue.npcName = name;
        trigger.dialogue.sentences = speech;
        friendship = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
}
