using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum inventoryItems {nothing, emptyWC, fullWC, axe, pileOfWood, torch, dynamite, litDynamite, dirtyGold, goldMedal  };
    public inventoryItems currentInventory;
    public List<Sprite> srList = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectFace(int faceSelected)
    {

    }
}
