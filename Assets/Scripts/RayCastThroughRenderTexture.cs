using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastThroughRenderTexture : MonoBehaviour
{
    private TouchControls touchers;
    /*if(Input.GetMouseButtonDown(0)) Debug.Log("Pressed left click.");
    if(Input.GetMouseButtonDown(1)) Debug.Log("Pressed right click.");
    if(Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle click.");*/
    public Camera cameraZoom;
    public LayerMask ForCubeFace, Forinteractables;
    public Collider annoyingBigCollider;
    // Start is called before the first frame update
    void Start()
    {
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

            if (Physics.Raycast(ray, out hit,ForCubeFace))
            {
                print(hit.collider.tag);
                if (hit.collider.CompareTag("CubeFace1"))
                {
                    
                    Vector2 localPoint = hit.textureCoord2;
                    print(localPoint);
                    hit.collider.gameObject.GetComponent<Material>().color = Color.blue;
                   /* Ray _ray = cameraZoom.ViewportPointToRay(localPoint);
                    RaycastHit _hit;
                    Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.red);
                    if (Physics.Raycast(_ray, out _hit,Forinteractables))
                    {
                        print("test 3");
                        
                        if (_hit.collider.tag == "dirt")
                        {
                            print("contacted");
                        }
                    }*/
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            annoyingBigCollider.enabled = true;
        }
    }
       
    

}
