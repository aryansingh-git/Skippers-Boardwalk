using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public Image interactImage;

    void Start()
    {
        interactImage.enabled = false; // Initially disable the Image
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                // If the player is within range of an interactable object, enable the Image
                interactImage.enabled = true;
                Debug.Log(hitInfo.distance);

                if (Input.GetKey(KeyCode.E))
                {
                    interactObj.Interact();
                    interactImage.enabled = false; // Disable the Image after interaction
                }
            }
            else
            {
                interactImage.enabled = false; // Disable the Image if no interactable object is in range
            }
      }
       
    }

}
