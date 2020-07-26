using UnityEngine;

public class Spawn : MonoBehaviour
{
    public bool DEBUG = true;
    public Transform nextDisplay;
    public GameObject[] groups;
    private GameObject displayedAsNext;

    private void Start()
    {
        PickNext();
        SpawnNext();
    }

    public void SpawnNext()
    {
        
        displayedAsNext.transform.position = transform.position;
        Group g = displayedAsNext.GetComponent<Group>();
        g.enabled = true;
        g.UpdateGrid();

        PickNext();
    }

    public void PickNext()
    {
        int i = Random.Range(0, groups.Length);
        GameObject go = Instantiate(
                groups[i],
                nextDisplay.position,
                Quaternion.identity);
        if (DEBUG) Debug.Log($"Next: {go.name}");
        displayedAsNext = go;
    }

}
