using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownThemeController : MonoBehaviour
{
    public GameObject parent;
    public List<string> townThemeNotes = new List<string>() {"C","D","E","F","G","c"};   //Possible notes for the towns theme
    public int[] townThemeNoteIndexes = new int[8];                            //Position of the notes in the list
    public Sprite[] noteSprites = new Sprite[6];
    public Color32[] noteColours = 
        new Color32[6] {
            new Color32(147,86,229,255),
            new Color32(229,85,85,255),
            new Color32(86,229,84,255),
            new Color32(241,117,41,255),
            new Color32(229,216,86,255),
            new Color32(86,212,229,255)
        };

    public void HideTownThemeCreator()
    {
       parent.SetActive(false);
    }
}
