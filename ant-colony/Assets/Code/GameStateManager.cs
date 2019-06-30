using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    private static GameStateManager _instance;
    public static GameStateManager Instance { get { return _instance; } }

    public Vector3 initialPlayerPosition;

    public GameObject deadPlayerPrefab;

    public List<GameObject> playerPrefabs;

    void Awake() {
        if (_instance == null){
            _instance = this;
        }
    }

    // Gets the latest player prefab. If all players have died then it returns null
    public GameObject getNextPlayer(){
        if (playerPrefabs.Count != 0) {
            var playerPrefab = playerPrefabs[0];
            playerPrefabs.RemoveAt(0);
            return playerPrefab;
        } else {
            // TODO: does such a thing exist as optional in C# to wrap around GameObject for the return type?
            return null;
        }
    }

    void Start() {
        SpawnPlayer();
    }

    public void OnDeath(Vector3 deathPosition){
        Instantiate(deadPlayerPrefab, deathPosition, Quaternion.identity);
    }

    public void SpawnPlayer() {
        var nextPlayer = this.getNextPlayer();
        if (nextPlayer != null) {
            Instantiate(nextPlayer, initialPlayerPosition, Quaternion.identity);
        } else {
            // TODO: GAME OVER
            Debug.Log("GAME OVER");
        }
    }
}