using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public int wood;
    public int berries;
    public int rock;
	private Text berriesText;
	private Text woodText;
	private Text rockText;

    private RayCast rayCast;

    void Awake()
    {
        rayCast = GameObject.Find("Main Camera").GetComponent<RayCast>();
		woodText = GameObject.Find ("Wood").GetComponent<Text> ();
		berriesText = GameObject.Find ("Berries").GetComponent<Text> ();
		rockText = GameObject.Find ("Rock").GetComponent<Text> ();
    }

	void Start() {

	}

    void Update ()
    {
		woodText.text = wood.ToString ();
		berriesText.text = berries.ToString ();
		rockText.text = rock.ToString ();
    }
}