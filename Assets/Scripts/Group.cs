using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Group : MonoBehaviour
{
    private Gameover gameoverUI;
    private Spawn spawner;
    private float lastFall = 0;
    // Start is called before the first frame update
    void Start()
    {
        //todo use GameEvent SO here
        gameoverUI = FindObjectOfType<Gameover>();
        spawner = FindObjectOfType<Spawn>(); 
        if (!IsValidGridPos())
        {
            gameoverUI.EndGame();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, -90);
            
            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.Rotate(0, 0, 90);
        } else if (
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) ||
            ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Time.time - lastFall >= .5f/2.5f) || 
            Time.time - lastFall >= .5f
            )
        {
            transform.position += new Vector3(0, -1, 0);
            if (IsValidGridPos())
            {
                UpdateGrid();
            } 
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Playfield.DeleteFullRows();
                spawner.SpawnNext();
                enabled = false;
            }
            lastFall = Time.time;
        }
    }

    private bool IsValidGridPos()
    {
        foreach(Transform child in transform)
        {
            Vector2 v = Playfield.RoundVec2(child.position);
            if (!Playfield.IsInsideBorder(v))
                return false;
            if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                Playfield.grid[(int)v.x, (int)v.y].parent != transform){
                return false;
            }
        }
        return true;
    }

    private void UpdateGrid()
    {
        for(int y = 0; y < Playfield.h; ++y)
            for(int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x,y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        foreach(Transform child in transform)
        {
            Vector2 v = Playfield.RoundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
