using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
    public string quest_name;
    public string[] objectives;
    public int on_objective;
    public int num_objectives;
    public int[] o_act, o_info;

    public Quest(string quest_name1, int num_objectives1) {
        quest_name = quest_name1;
        num_objectives = num_objectives1;
        on_objective = 0;
        objectives = new string[num_objectives];
        o_act = new int[num_objectives];
        o_info = new int[num_objectives];
    }
}