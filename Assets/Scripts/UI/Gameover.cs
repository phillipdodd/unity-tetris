using UnityEngine;

public class Gameover : MonoBehaviour
{

    public GameObject restartUI;
    public Spawn spawner;

    private ScoreController scoreController;

    private void Start()
    {
        scoreController = GetComponent<ScoreController>();
    }

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
        scoreController.ResetScore();
        //todo replace with GameEvent SO's
        Playfield.DeleteAllBlocks();
        restartUI.SetActive(false);
        spawner.PickNext();
        spawner.SpawnNext();
    }
}
