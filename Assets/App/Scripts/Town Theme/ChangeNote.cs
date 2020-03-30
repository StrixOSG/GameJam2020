using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeNote : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentNote;
    [SerializeField]
    private int noteNumber;
    [SerializeField]
    private TownThemeController townThemeController;
    private int currentNoteIndex;

    void Start(){

        currentNoteIndex = 0;
        currentNote.text = townThemeController.townThemeNotes[currentNoteIndex];
        GetComponent<Image>().color = townThemeController.noteColours[currentNoteIndex];
            
    }
    
    public void NextNote(){

        //Next index (note)
        if(currentNoteIndex == 0){
            
            currentNoteIndex = 5;

        }else{

            currentNoteIndex--;

        }

        UpdateNote();

    }

    public void PreviousNote(){

        //Previous index (note)
        if(currentNoteIndex == 5){
            
            currentNoteIndex = 0;

        }else{

            currentNoteIndex++;

        }

        UpdateNote();

    }

    public void UpdateNote(){

        //Display the note currently selected as text
        currentNote.text = townThemeController.townThemeNotes[currentNoteIndex];

        //Display the colour associated with the note
        GetComponent<Image>().color = townThemeController.noteColours[currentNoteIndex];

        //Display the note currently selected as an image
        //GetComponent<Image>().sprite = townThemeController.noteSprites[currentNoteIndex];

        //Update the town theme
        townThemeController.townThemeNoteIndexes[noteNumber] = currentNoteIndex;

    }

}
