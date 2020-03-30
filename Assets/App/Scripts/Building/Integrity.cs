using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{

    public int status;
    public int cost;
    GameObject broken;
    GameObject fixeds;

    // Start is called before the first frame update
    void Start() {
        broken = transform.GetChild(0).gameObject;
        fixeds = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (status == 1 && (broken.activeSelf || !fixeds.activeSelf)) {
            broken.SetActive(false);
            fixeds.SetActive(true);
        }

        if (status == 0 && (!broken.activeSelf || fixeds.activeSelf)) {
            broken.SetActive(true);
            fixeds.SetActive(false);
        }

    }

    void OnMouseDown() {
        //Find player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int num = -1;

        for(int i = 0; i < players.Length; i++)
            if(Vector3.Distance(players[i].transform.position, transform.position) < 3.0f) num = i;

        if (num >= 0) {

            if(players[num].GetComponent<Inventory>().logs >= cost) {
                players[num].GetComponent<Inventory>().logs -= cost;
                status = 1;
            }
        }
    }
}
