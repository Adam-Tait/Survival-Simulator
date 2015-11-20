using UnityEngine;
using System.Collections;

public class BerryCollect : MonoBehaviour {

    public int maxBerry;
    public int currentBerry;

    void Start () {
        maxBerry = Random.Range(5, 15);
        currentBerry = maxBerry;
	}
}
