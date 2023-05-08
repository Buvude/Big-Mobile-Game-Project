using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory inv;
    public Material Shelves, Field, Fireplace, Cave, Storage, Trophies;
    public enum faceState { locked, unlocked, item1Taken, item2Taken, item3Taken, interaction1Done, interaction2Done, interaction3Done};
    public List<SpriteRenderer> ShelvesSprites = new List<SpriteRenderer>();
    public List<SpriteRenderer> FieldSprites = new List<SpriteRenderer>();
    public List<SpriteRenderer> FireplaceSprites = new List<SpriteRenderer>();
    public List<SpriteRenderer> CaveSprites = new List<SpriteRenderer>();
    public List<SpriteRenderer> StorageSprites = new List<SpriteRenderer>();
    public List<SpriteRenderer> TrophiesSprites = new List<SpriteRenderer>();
    public faceState shelvesFS, fieldFS, fireplaceFS, caveFS, storageFS, trophiesFS; 
    private faceState psShevles, psField, psCave, psStorage;
    // Start is called before the first frame update
    /// <summary>
    /// Setting up all starting states for the faces
    /// </summary>
    void Start()
    {
        shelvesFS = faceState.unlocked;
        fieldFS = faceState.unlocked;
        fireplaceFS = faceState.locked;
        caveFS = faceState.locked;
        storageFS = faceState.locked;
        trophiesFS = faceState.locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This is only for updating the apearance of the faces, it does not update gamestate or anything
    /// </summary>
    public void updateFaces()
    {
        switch (shelvesFS)
        {

            case faceState.unlocked://default state
                ShelvesSprites[0].enabled = true;
                break;
            case faceState.item1Taken://watering can taken
                psShevles = faceState.unlocked;
                ShelvesSprites[0].enabled = false;
                ShelvesSprites[1].enabled = true;
                break;
            case faceState.item2Taken://axe taken
                psShevles = faceState.item1Taken;
                ShelvesSprites[1].enabled = false;
                break;
            default:
                break;
        }
        switch (fieldFS)
        {
            case faceState.unlocked://default state
                break;
            case faceState.item1Taken://taken the wood
                psField = faceState.interaction1Done;
                FieldSprites[0].enabled = false;
                FieldSprites[1].enabled = true;
                FieldSprites[2].enabled = false;
                break;
            case faceState.interaction1Done://tree chopped down
                FieldSprites[0].enabled = false;
                FieldSprites[1].enabled = true;
                FieldSprites[2].enabled = true;
                break;
            default:
                break;
        }
        switch (fireplaceFS)
        {
            case faceState.locked://default state
                break;
            case faceState.unlocked://will show the background
                Fireplace.color = Color.white;
                break;
            case faceState.interaction1Done://place wood
                FireplaceSprites[0].enabled = true;
                break;
            case faceState.interaction2Done://light fire
                FireplaceSprites[1].enabled = true;
                break;
            default:
                break;
        }
        switch (caveFS)
        {
            case faceState.locked://default state
                break;
            case faceState.unlocked://once unlocked these two sprites will render, and background will render
                Cave.color = Color.white;
                CaveSprites[0].enabled = true;
                CaveSprites[1].enabled = true;
                break;
            case faceState.item1Taken://torch taken
                psCave = faceState.unlocked;
                CaveSprites[1].enabled = false;
                break;
            case faceState.item2Taken:
                psCave = faceState.interaction1Done;
                CaveSprites[2].enabled = false;
                break;
            case faceState.interaction1Done://blown up rocks
                CaveSprites[0].enabled = false;
                CaveSprites[2].enabled = true;
                break;
            default:
                break;
        }

        switch (storageFS)
        {
            case faceState.locked://default state
                break;
            case faceState.unlocked://when unlocked background will show and sprite will render
                Storage.color = Color.white;
                StorageSprites[0].enabled = true;
                break;
            case faceState.item1Taken://taken unlit dynamite
                psStorage = faceState.unlocked;
                StorageSprites[0].enabled = false;
                break;
            default:
                break;
        }

        switch (trophiesFS)
        {
            case faceState.locked://default state
                break;
            case faceState.unlocked://background will show
                Trophies.color = Color.white;
                break;
            case faceState.interaction1Done://medal placed, game won
                TrophiesSprites[0].enabled = true;
                break;
            default:
                break;
        }
        
    }
    public void ReturnItem(int itemNumber)
    {
        switch (itemNumber)
        {
            case 1://empty watering can
                shelvesFS = psShevles;
                updateFaces();
                break;
            case 2://full Watering Can
                //TODO make function for if an item cannot be returned
                break;
            case 3://Axe
                shelvesFS = psShevles;
                updateFaces();
                break;
            case 4://wood
                fieldFS = psField;
                updateFaces();
                break;
            case 5://torch
                caveFS = psCave;
                updateFaces();
                break;
            case 6://unlit dynamite
                storageFS = psStorage;
                updateFaces();
                break;
            case 7://lit dynamite
                //TODO make function for if an item cannot be returned
                break;
            case 8://Dirty gold
                caveFS = psCave;
                updateFaces();
                break;
            case 9://medal
                //TODO make function for if an item cannot be returned
                break;
            default:
                break;
        }
    }

}
