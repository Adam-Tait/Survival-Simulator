using UnityEngine;
using System.Collections;
public class RayCast : MonoBehaviour {

    private TreeChop treeChop;
    private BerryCollect berryCollect;
    private RockSmash rockSmash;
    private float distance = 1.5f;
    private Inventory inventory;
    public int saveWood;
    public int saveBerries;
    public int saveRock;
    private float coolDown = 0f;
    public float maxCooldown = 1.0f;


    void Awake ()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        saveWood = PlayerPrefs.GetInt("Wood");
        saveBerries = PlayerPrefs.GetInt("Berry");
        saveRock = PlayerPrefs.GetInt("Rock");
    }
	
	// Update is called once per frame
	void Update () {
        coolDown -= Time.deltaTime;
        if (coolDown < 0)
        {
            coolDown = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance) && coolDown <= 0)
            {
                if (hit.collider.gameObject.tag == "Tree")
                {
                    treeChop = GameObject.Find(hit.collider.gameObject.name).GetComponent<TreeChop>();
                    treeChop.currentWood -= 1;
                    inventory.wood += 1;
                    PlayerPrefs.SetInt("Wood", inventory.wood + saveWood);
                    coolDown = maxCooldown;
                    if(treeChop.currentWood <= 0)
                    {
                        GameObject.Find(hit.collider.gameObject.name).SetActive(false);
                    }
                }
                else if (hit.collider.gameObject.tag == "Bush")
                {
                    berryCollect = GameObject.Find(hit.collider.gameObject.name).GetComponent<BerryCollect>();
                    berryCollect.currentBerry -= 1;
                    inventory.berries += 1;
                    PlayerPrefs.SetInt("Berry", inventory.berries + saveBerries);
                    coolDown = maxCooldown;
                    if (berryCollect.currentBerry <= 0)
                    {
                        GameObject.Find(hit.collider.gameObject.name).SetActive(false);
                    }
                }
                else if (hit.collider.gameObject.tag == "Rock")
                {
                    rockSmash = GameObject.Find(hit.collider.gameObject.name).GetComponent<RockSmash>();
                    rockSmash.currentRock -= 1;
                    inventory.rock += 1;
                    PlayerPrefs.SetInt("Rock", inventory.rock + saveRock);
                    coolDown = maxCooldown;
                    if (rockSmash.currentRock <= 0)
                    {
                        GameObject.Find(hit.collider.gameObject.name).SetActive(false);
                    }
                }
            }
        }
	}
}
