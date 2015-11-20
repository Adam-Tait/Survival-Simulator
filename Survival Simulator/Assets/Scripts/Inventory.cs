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

    void Update ()
    {
        wood = rayCast.saveWood;
        berries = rayCast.saveBerries;
        rock = rayCast.saveRock;
    }
}