using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastThroughRenderTexture : MonoBehaviour
{
    public Camera cameraZoom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);
            if (hit.collider.tag == "CubeFace1")
            {
                Vector2 localPoint = hit.textureCoord;
                Ray _ray = cameraZoom.ViewportPointToRay(localPoint);
                RaycastHit _hit;
                if (Physics.Raycast(_ray, out _hit))
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.green);
                    if (_hit.collider.tag == "dirt")
                    {
                        print("contacted ");
                    }
                }
            }
        }
    }
}
