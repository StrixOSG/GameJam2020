using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    void OnMouseDown() {
        //Find player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++) {
            if (Vector3.Distance(players[i].transform.position, transform.position) < 3.0f) {
                players[i].GetComponent<Inventory>().logs += (int)Random.Range(2, 5);
                players[i].GetComponent<Inventory>().coins += (int)(Random.Range(0.0f, 1.99f));
                float new_x = Random.Range(-2.0f, 15.0f);
                float new_y = Random.Range(7.4f, 15.0f);
                transform.position = new Vector3(new_x, new_y, 0.0f);
                break;
            }
        }
    }
}
