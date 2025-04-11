using UnityEngine;

public class PaperManager : MonoBehaviour
{
    public int totalPapers = 6; // Total number of papers in the scene
    public GameObject objectToEnable; // The GameObject to enable when all papers are dropped
    private int droppedPapers = 0; // Counter for dropped papers

    // Call this method from the Paper script when a paper is dropped
    public void PaperDropped()
    {
        droppedPapers++;

        if (droppedPapers >= totalPapers)
        {
            objectToEnable.SetActive(true);
        }
    }
}
