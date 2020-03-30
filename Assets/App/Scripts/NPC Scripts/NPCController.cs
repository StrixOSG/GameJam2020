using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public static List<string> NPCNames = 
        new List<string>() {
            "Chad",
            "Frank",
            "Karrie",
            "Leo",
            "Yvonne"};

    public Yvonne yvonne;
    public Karrie karrie;
    public Leo leo;
    public Frank frank;
    public Chad chad;
    public static Dictionary<string, int> friendship;

    void Start(){

        friendship = new Dictionary<string, int>();
        friendship.Add("Yvonne", yvonne.friendship);
        friendship.Add("Karrie", karrie.friendship);
        friendship.Add("Leo", leo.friendship);
        friendship.Add("Frank", frank.friendship);
        friendship.Add("Chad", chad.friendship);

    }

    void Update(){

        friendship["Yvonne"] = yvonne.friendship;
        friendship["Karrie"] = karrie.friendship;
        friendship["Leo"] = leo.friendship;
        friendship["Frank"] = frank.friendship;
        friendship["Chad"] = chad.friendship;

    }
    
}
