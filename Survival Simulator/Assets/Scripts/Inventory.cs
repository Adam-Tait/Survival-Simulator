using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public int wood;
    public int berries;
    public int rock;
    private RayCast rayCast;

    void Awake()
    {
        rayCast = GameObject.Find("Main Camera").GetComponent<RayCast>();
    }

    void Start ()
    {
        wood = wood + rayCast.saveWood;
        berries = berries + rayCast.saveBerries;
        rock = rock + rayCast.saveRock;
    }
}