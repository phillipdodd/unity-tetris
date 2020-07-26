using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform nextDisplay;
    public GameObject[] groups;
    private GameObject displayed;

    private void Start()
    {
        PickNext();
        SpawnNext();
    }

    public void SpawnNext()
    {
        if (displayed == null)
            PickNext();

        displayed.transform.position = transform.position;
        Group g = displayed.GetComponent<Group>();
        g.IsOnDisplay = false;
        g.UpdateGrid();

        PickNext();
    }

    private void PickNext()
    {
        int i = Random.Range(0, groups.Length);
        GameObject go = Instantiate(
                groups[i],
                nextDisplay.position,
                Quaternion.identity);
        displayed = go;
    }

}
