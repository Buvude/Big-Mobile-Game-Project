using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public enum inventoryItems {nothing, emptyWC, fullWC, axe, pileOfWood, torch, dynamite, litDynamite, dirtyGold, goldMedal  };
    public inventoryItems currentInventory;
    public List<Sprite> srList = new List<Sprite>();
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateInventory()
    {
        switch (currentInventory)
        {
            case inventoryItems.nothing:
                this.GetComponent<Image>().sprite = srList[0];
                break;
            case inventoryItems.emptyWC:
                this.GetComponent<Image>().sprite = srList[1];
                break;
            case inventoryItems.fullWC:
                this.GetComponent<Image>().sprite = srList[2];
                break;
            case inventoryItems.axe:
                this.GetComponent<Image>().sprite = srList[3];
                break;
            case inventoryItems.pileOfWood:
                this.GetComponent<Image>().sprite = srList[4];
                break;
            case inventoryItems.torch:
                this.GetComponent<Image>().sprite = srList[5];
                break;
            case inventoryItems.dynamite:
                this.GetComponent<Image>().sprite = srList[6];
                break;
            case inventoryItems.litDynamite:
                this.GetComponent<Image>().sprite = srList[7];
                break;
            case inventoryItems.dirtyGold:
                this.GetComponent<Image>().sprite = srList[8];
                break;
            case inventoryItems.goldMedal:
                this.GetComponent<Image>().sprite = srList[9];
                break;
            default:
                break;
        }
    }
    public void unlock(int unlocknumber)
    {
        if (unlocknumber == 1)
        {
            currentInventory = inventoryItems.nothing;
            gm.shelvesFS = GameManager.faceState.item2Taken;
            gm.fireplaceFS = GameManager.faceState.unlocked;
            gm.caveFS = GameManager.faceState.unlocked;
            updateInventory();
            gm.updateFaces();
        }
        else if (unlocknumber == 2)
        {
            currentInventory = inventoryItems.nothing;
            gm.fireplaceFS = GameManager.faceState.interaction2Done;
            gm.storageFS = GameManager.faceState.unlocked;
            gm.trophiesFS = GameManager.faceState.unlocked;
            updateInventory();
            gm.updateFaces();
        }
    }
    public void SelectFace(int faceSelected)
    {
        switch (faceSelected)
        {

            case 1:
                switch (gm.shelvesFS)
                {
                    case GameManager.faceState.unlocked:
                        currentInventory = inventoryItems.emptyWC;
                        gm.shelvesFS = GameManager.faceState.item1Taken;
                        updateInventory();
                        gm.updateFaces();
                        break;
                    case GameManager.faceState.item1Taken:
                        if (currentInventory == inventoryItems.fullWC)
                        {
                            unlock(1);
                        }
                        break;
                    case GameManager.faceState.item2Taken:
                        if (currentInventory != inventoryItems.nothing&&currentInventory!=inventoryItems.axe)
                        {
                            returnItem();
                        }
                        currentInventory = inventoryItems.axe;
                        gm.shelvesFS = GameManager.faceState.item3Taken;
                        updateInventory();
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (gm.fieldFS)
                {
                    case GameManager.faceState.unlocked:
                        if (currentInventory != inventoryItems.nothing && currentInventory != inventoryItems.emptyWC&&currentInventory!=inventoryItems.axe)
                        {
                            returnItem();
                        }
                        if (currentInventory == inventoryItems.emptyWC)
                        {
                            currentInventory = inventoryItems.fullWC;
                            updateInventory();
                        }
                        else if (currentInventory == inventoryItems.axe)
                        {
                            currentInventory = inventoryItems.nothing;
                            gm.fieldFS = GameManager.faceState.interaction1Done;
                            updateInventory();
                            gm.updateFaces();
                        }
                        break;
                    case GameManager.faceState.item1Taken:
                        if (currentInventory == inventoryItems.dirtyGold)
                        {
                            currentInventory = inventoryItems.goldMedal;
                            updateInventory();
                        }
                        break;
                    case GameManager.faceState.interaction1Done:
                        if (currentInventory != inventoryItems.nothing)
                        {
                            returnItem();
                        }
                        currentInventory = inventoryItems.pileOfWood;
                        gm.fieldFS = GameManager.faceState.item1Taken;
                        updateInventory();
                        gm.updateFaces();
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (gm.fireplaceFS)
                {
                    case GameManager.faceState.unlocked:
                        if (currentInventory == inventoryItems.pileOfWood)
                        {
                            currentInventory = inventoryItems.nothing;
                            gm.fireplaceFS = GameManager.faceState.interaction1Done;
                            updateInventory();
                            gm.updateFaces();
                        }
                        break;
                    case GameManager.faceState.interaction1Done:
                        if (currentInventory == inventoryItems.torch)
                        {
                            unlock(2);
                        }
                        break;
                    case GameManager.faceState.interaction2Done:
                        if (currentInventory == inventoryItems.dynamite)
                        {
                            currentInventory = inventoryItems.litDynamite;
                            updateInventory();
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                switch (gm.caveFS)
                {
                    case GameManager.faceState.unlocked:
                        if (currentInventory != inventoryItems.nothing)
                        {
                            returnItem();
                        }
                        currentInventory = inventoryItems.torch;
                        gm.caveFS = GameManager.faceState.item1Taken;
                        updateInventory();
                        gm.updateFaces();
                        break;
                    case GameManager.faceState.item1Taken:

                        if (currentInventory == inventoryItems.litDynamite)
                        {
                            currentInventory = inventoryItems.nothing;
                            gm.caveFS = GameManager.faceState.interaction1Done;
                            updateInventory();
                            gm.updateFaces();
                        }
                        
                        break;
                    case GameManager.faceState.interaction1Done:
                        if (currentInventory != inventoryItems.nothing)
                        {
                            returnItem();
                        }
                        currentInventory = inventoryItems.dirtyGold;
                        gm.caveFS = GameManager.faceState.item2Taken;
                        updateInventory();
                        gm.updateFaces();
                        break;
                    default:
                        break;
                }
                break;
            case 5:
                switch (gm.storageFS)
                {
                    case GameManager.faceState.unlocked:
                        if (currentInventory != inventoryItems.nothing)
                        {
                            returnItem();
                        }
                        currentInventory = inventoryItems.dynamite;
                        gm.storageFS = GameManager.faceState.item1Taken;
                        updateInventory();
                        gm.updateFaces();
                        break;
                    default:
                        break;
                }
                break;
            case 6:
                if (currentInventory == inventoryItems.goldMedal && gm.trophiesFS == GameManager.faceState.unlocked)
                {
                    currentInventory = inventoryItems.nothing;
                    gm.trophiesFS = GameManager.faceState.interaction1Done;
                    updateInventory();
                    gm.updateFaces();
                }
                break;
            default:
                break;
        }
    }
    public void returnItem()
    {
        switch (currentInventory)
        {
            case inventoryItems.emptyWC:
                gm.ReturnItem(1);
                break;
            case inventoryItems.fullWC:
                gm.ReturnItem(2);
                break;
            case inventoryItems.axe:
                gm.ReturnItem(3);
                break;
            case inventoryItems.pileOfWood:
                gm.ReturnItem(4);
                break;
            case inventoryItems.torch:
                gm.ReturnItem(5);
                break;
            case inventoryItems.dynamite:
                gm.ReturnItem(6);
                break;
            case inventoryItems.litDynamite:
                gm.ReturnItem(7);
                break;
            case inventoryItems.dirtyGold:
                gm.ReturnItem(8);
                break;
            case inventoryItems.goldMedal:
                gm.ReturnItem(9);
                break;
            default:
                break;
        }
    }
}
