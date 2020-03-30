using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayQuestInfo : MonoBehaviour
{

    public bool toggled; //false = hidden, true = shown
    public GameObject toggleQuestDisplayIcon;
    public GameObject questDisplayBackground;
    public Sprite[] toggleIcons = new Sprite[2];
    public TextMeshProUGUI questText, objectiveText;
    public CurrentQuest currentQuest;

    void Start(){

        toggled = false;
        questDisplayBackground.SetActive(false);
        toggleQuestDisplayIcon.GetComponent<Image>().sprite = toggleIcons[Convert.ToInt32(toggled)];

    }

    public void Toggle(){

        toggled = !toggled;
        toggleQuestDisplayIcon.GetComponent<Image>().sprite = toggleIcons[Convert.ToInt32(toggled)];
        questDisplayBackground.SetActive(toggled);

    }

    public void Update(){

        int questNum = currentQuest.quest_num;
        int objectiveNum = currentQuest.ob_num;

        questText.text = currentQuest.quests[questNum].quest_name;
        objectiveText.text = currentQuest.quests[questNum].objectives[objectiveNum];

    }

}
