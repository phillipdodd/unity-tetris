using UnityEngine;

public class Gameover : MonoBehaviour
{

    public GameObject restartUI;
    public Spawn spawner;

    void Update()
    {
        if (restartUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void EndGame()
    {
        restartUI.SetActive(true);
    }

    public void RestartGame()
    {
        //todo replace with GameEvent SO's
        Playfield.DeleteAllBlocks();
        restartUI.SetActive(false);
        spawner.SpawnNext();
    }
}
