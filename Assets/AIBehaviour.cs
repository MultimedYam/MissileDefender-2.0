using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class AIBehaviour : MonoBehaviour
{
    public List<int> LocalTiles;
    public List<int> LocalCities;
    public List<int> EnemyTiles;

    public GameObject GameManager;

    [Range(0, 1)]
    public float ChanceToHit;

    public float MinTime;
    public float MaxTime;
    private float time;
    private float spawnTime;

    private int CitiesDestroyed;

    public void AssignAIAttributes()
    {
        int total = GameObject.Find("WorldBuilder").GetComponent<WorldBuilder>().TotalTiles;
        for (int i = 1; i <= total / 2; i++)
        {
            LocalTiles.Add(i);
            EnemyTiles.Add(i);
        }

        int maxCities = GameManager.GetComponent<GameAttributes>().MaxAllowedCities;
        for (int i = 0; i < maxCities; i++)
        {
            int cityLoc = Random.Range(0, LocalTiles.Count - 1);
            while(LocalCities.Contains(cityLoc))
            {
                cityLoc = Random.Range(0, LocalTiles.Count - 1);
            }
            LocalCities.Add(LocalTiles[cityLoc]);
        }
        print("Added AI attributes");
    }

    void Start()
    {
        spawnTime = Random.Range(MinTime, MaxTime);
        time = MinTime;
    }
    void Update()
    {
        if (CitiesDestroyed == 3)
        {
            //End Game (WIN)
            GameManager.GetComponent<GameActions>().EndGame(GameActions.GameFinisher.win);
        }

        if(GameManager.GetComponent<GameActions>().gameStarted == true)
        {
            time += Time.deltaTime;

            if(time >= spawnTime)
            {
                time = 0;
                int TileToFireTo = EnemyTiles[Random.Range(0, EnemyTiles.Count - 1)];
                GameManager.GetComponent<GameActions>().LaunchIncomingProjectile(TileToFireTo);

                spawnTime = Random.Range(MinTime, MaxTime);
            }
        }

    }

    public void OnMissileHit(int tileNr)
    {
        EnemyTiles.Remove(tileNr);
    }


    /// <returns>
    /// -1 : Missile blocked (RNG)
    ///  0 : Target missed
    ///  1 : Target hit (City destroyed)
    /// </returns>
    public int ReceiveMissile(int x, int y)
    {
        WorldBuilder builder = GameObject.Find("WorldBuilder").GetComponent<WorldBuilder>();
        int Destination = ((y * builder.GridX) + x + 1) - builder.TotalTiles/2;

        int missileHit = 0;

        float hitValue = Random.Range(0, 1.00f);
        if (ChanceToHit > hitValue)
        {
            if (LocalCities.Contains(Destination))
            {
                missileHit = 1;
                LocalCities.Remove(Destination);
                CitiesDestroyed++;
            }
            else
            {
                missileHit = 0;
            }
        }
        else
        {
            missileHit = -1;
        }
        return missileHit;
    }
}
