using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.StudioEventEmitter intro;
    public FMODUnity.StudioEventEmitter main;
    public TownThemeController controller;
    public Inventory inventory;

    public Integrity house;
    bool ranOnce = false;
    void Start()
    {

        intro.Play();
       
    }

    // Update is called once per frame
    void Update()
    {
        intro.SetParameter("Note 1", controller.townThemeNoteIndexes[0]);
        intro.SetParameter("Note 2", controller.townThemeNoteIndexes[1]);
        intro.SetParameter("Note 3", controller.townThemeNoteIndexes[2]);
        intro.SetParameter("Note 4", controller.townThemeNoteIndexes[3]);
        intro.SetParameter("Note 5", controller.townThemeNoteIndexes[4]);
        intro.SetParameter("Note 6", controller.townThemeNoteIndexes[5]);
        intro.SetParameter("Note 7", controller.townThemeNoteIndexes[6]);
        intro.SetParameter("Note 8", controller.townThemeNoteIndexes[7]); 

        //music swells based on progression to 100 logs
            intro.SetParameter("Distance to House", inventory.logs);
        
        if(house.status == 1 && !ranOnce)
        {
            intro.SetParameter("At House", inventory.logs);
            ranOnce = true;
            StartCoroutine(waitForHouse());
        }
    }

    private IEnumerator waitForHouse()
    {
        yield return new WaitForSeconds(4);
        main.Play();

        main.SetParameter("Note 1", controller.townThemeNoteIndexes[0]);
        main.SetParameter("Note 2", controller.townThemeNoteIndexes[1]);
        main.SetParameter("Note 3", controller.townThemeNoteIndexes[2]);
        main.SetParameter("Note 4", controller.townThemeNoteIndexes[3]);
        main.SetParameter("Note 5", controller.townThemeNoteIndexes[4]);
        main.SetParameter("Note 6", controller.townThemeNoteIndexes[5]);
        main.SetParameter("Note 7", controller.townThemeNoteIndexes[6]);
        main.SetParameter("Note 8", controller.townThemeNoteIndexes[7]); 
        
        gameObject.SetActive(false);
    }
}
