using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Paper : MonoBehaviour, IInteractable
{
    public Collider objectCollider; // The Collider to disable
    public bool isPickedUp { get; private set; } = false;
    private Transform player;
    public Transform dropPosition; // The position where the paper will be dropped
    public Vector3 dropRotation; // The rotation of the paper when dropped
    public PaperManager paperManager; // Assign the PaperManager in the Unity editor
    public Interactor interactor; // Add this line to have a reference to the Interactor

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactor = player.GetComponent<Interactor>(); // Get the Interactor component from the player
    }

    public void Interact()
    {
        if (!isPickedUp)
        {
            // Code to pick up the paper
            PickUpPaper();
        }
    }

    private void PickUpPaper()
    {
        // Make the paper a child of the player's game object
        this.transform.SetParent(player);
        // Update the position of the paper to be in front of the player
        this.transform.position = player.position + player.forward;
        isPickedUp = true;
        interactor.enabled = false; // Disable the Interactor script when the paper is picked up
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPickedUp && other.gameObject.CompareTag("Drop Paper"))
        {
            // Code to drop the paper
            DropPaper();
        }
    }

    private void DropPaper()
    {
        // Remove the paper as a child of the player's game object
        this.transform.SetParent(null);
        // Update the position of the paper to the drop position
        this.transform.position = dropPosition.position;
        // Change the rotation of the paper
        this.transform.rotation = Quaternion.Euler(dropRotation); // Use the public dropRotation
        isPickedUp = false;
        paperManager.PaperDropped(); // Notify the PaperManager that a paper has been dropped
        objectCollider.enabled = false;
        interactor.enabled = true; // Re-enable the Interactor script when the paper is dropped
    }
}
