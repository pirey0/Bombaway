using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupHandler : Singleton<PickupHandler>
{
    [SerializeField] float holdForce;

    IPickupable pickup;

    Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }


    private void Update()
    {
        bool justClicked = Input.GetMouseButtonDown(0);
        bool clicked = Input.GetMouseButton(0);

        var raycastTarget = Raycast();

        if(pickup == null)
        {
            if (justClicked)
            {
                if(raycastTarget == null)
                {
                    return;
                }

                var pickupable = raycastTarget.GetComponent<IPickupable>();

                if (pickupable != null)
                {
                    pickup = pickupable;
                    pickup.PickUp();
                }
                else
                {
                    var clickable = raycastTarget.GetComponent<IClickable>();
                    clickable?.Click();
                }
            }
        }
        else
        {
            if(pickup.GetTransform() == null)
            {
                pickup = null;
                return;
            }
            
            Vector3 force = (GetMousePos() - pickup.GetTransform().position) * holdForce * Time.deltaTime;
            
            pickup.GetRigidbody().AddForce(force);
            pickup.GetRigidbody().velocity = pickup.GetRigidbody().velocity * 0.9f;

            if (!clicked)
            {
                pickup.Release();
                pickup = null;
            }
        }

    }

    private Vector3 GetMousePos()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        Plane p = new Plane(Vector3.forward, Vector3.zero);
        float outDist;
        if(p.Raycast(ray, out outDist))
        {
            return ray.GetPoint(outDist);
        }

        Debug.Log("Mouse not pointing at plane");
        return Vector3.zero;
    }


    private Transform Raycast()
    {

        var ray = camera.ScreenPointToRay(Input.mousePosition);

        var hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit.transform;
    }
}
