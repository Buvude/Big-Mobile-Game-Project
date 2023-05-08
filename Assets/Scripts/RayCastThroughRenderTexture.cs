using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastThroughRenderTexture : MonoBehaviour
{
    public Inventory inv;
    public GameManager gM;
    private TouchControls touchers;
    /*if(Input.GetMouseButtonDown(0)) Debug.Log("Pressed left click.");
    if(Input.GetMouseButtonDown(1)) Debug.Log("Pressed right click.");
    if(Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle click.");*/
    public Camera cameraZoom;
    public LayerMask ForCubeFace;
    public Collider annoyingBigCollider;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("eventSystem").GetComponent<GameManager>();
        touchers = new TouchControls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //This is a bad idea... but oh well. I'm deactivating one of the colliders to allow the whole thing to function.
            annoyingBigCollider.enabled = false;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);

            if (Physics.Raycast(ray, out hit, ForCubeFace))
            {
                print(hit.collider.tag);
                if (hit.collider.CompareTag("CubeFace1"))
                {
                    inv.SelectFace(1); 
                }
                else if (hit.collider.CompareTag("CubeFace2"))
                {
                    inv.SelectFace(2);
                }
                else if (hit.collider.CompareTag("CubeFace3"))
                {
                    inv.SelectFace(3);
                }
                else if (hit.collider.CompareTag("CubeFace4"))
                {
                    inv.SelectFace(4);
                }
                else if (hit.collider.CompareTag("CubeFace5"))
                {
                    inv.SelectFace(5);
                }
                else if (hit.collider.CompareTag("CubeFace6"))
                {
                    inv.SelectFace(6);
                }
            }
        }
        else if (Input.touchCount >= 1)
        {
            annoyingBigCollider.enabled = false;


            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);

            if (Physics.Raycast(ray, out hit, ForCubeFace))
            {
                print(hit.collider.tag);
                if (hit.collider.CompareTag("CubeFace1"))
                {
                    gM.Shelves.color = Color.blue;
                }
            }
            if (Input.touchCount == 0)
            {
                annoyingBigCollider.enabled = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                annoyingBigCollider.enabled = true;
            }

        }

    }   

}
