using UnityEngine;
using System.Collections;

public class TreeChop : MonoBehaviour {

    public int maxWood;
    public int currentWood;
    public float treeRespawn = 0.0f;
    public float maxTreeRespawn;

    void Start()
    {
        maxWood = Random.Range(2, 6);
        currentWood = maxWood;
        maxTreeRespawn = Random.Range(10.0f, 15.0f);
        treeRespawn = maxTreeRespawn;
    }

    void Update ()
    {
        if (currentWood == 0)
        {
            treeRespawn -= Time.deltaTime;
            if (treeRespawn <= 0)
            {
                treeRespawn = 0;
                if (treeRespawn == 0)
                {
                    // add respawning here
                }
            }
        }
    }
}
