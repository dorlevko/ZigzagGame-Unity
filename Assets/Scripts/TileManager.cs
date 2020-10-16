using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject currentTile;
    private static TileManager instance;
    
    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles { get => leftTiles; set => leftTiles = value; }
    public Stack<GameObject> TopTiles { get => topTiles; set => topTiles = value; }

    
    public static TileManager Instance 
    { 
        get
        {
            if (instance == null){
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }   
    }

    void Start()
    {
        //CreateTiles(5);
        for (int i = 0; i < 10; i++)
        {
            SpawnTiles();
        }
    }

    public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));
            TopTiles.Peek().name = "TopTile";
            TopTiles.Peek().SetActive(false);
            LeftTiles.Peek().name = "LeftTile";
            LeftTiles.Peek().SetActive(false);
        }
    }

    public void SpawnTiles()
    {
        if (LeftTiles.Count == 0 || TopTiles.Count == 0)
        {
            CreateTiles(10);
        }
       
        int randomIndex = Random.Range(0,tilePrefabs.Length);

        if (randomIndex == 0)
        {
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnPickup = Random.Range(0,10);

        if (spawnPickup == 0){
            currentTile.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
