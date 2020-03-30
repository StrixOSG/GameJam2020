using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public int logs;
    public int coins;
    public int special;
    public Sprite[] specialSprites = new Sprite[7];
    /*  0 = None (Empty icon - star)
     *  1 = Cocoa beans
     *  2 = Gift box
     *  3 = Carrots
     *  4 = Protein bar
     *  5 = Bread
     *  6 = Straws
     */
     public TextMeshProUGUI logText, coinText;
     public Image specialSprite;

    // Start is called before the first frame update
    void Start() {
        logText.text = "x 0";
        coinText.text = "x 0";
    }

    // Update is called once per frame
    void Update() {

        logText.text = "x " + logs.ToString();
        coinText.text = "x " + coins.ToString();
        specialSprite.sprite = specialSprites[special];

    }
}
