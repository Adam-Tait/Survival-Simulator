using UnityEngine;
using System.Collections;

public class RockSmash : MonoBehaviour {

    public int maxRock;
    public int currentRock;

	void Start () {
        maxRock = Random.Range(2, 4);
        currentRock = maxRock;
	}
}
