using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    private static GameStateManager _instance;
    public static GameStateManager Instance { get { return _instance; } }

    public Vector3 initialPosition;

    // TODO: this will probably need to be a list of deadplayerprefabs and their dead positions
    public GameObject deadplayerPrefab;

    // TODO: List of player prefabs to grab from

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
        // TODO: instantiate the first player
        var initialPlayer = getNextPlayer();
        Instantiate(initialPlayer, initialPosition, Quaternion.identity);
    }

    public void OnDeath(Vector3 deathPosition){
        Instantiate(deadplayerPrefab, deathPosition, Quaternion.identity);
        var nextPlayer = this.getNextPlayer();
        if (nextPlayer != null) {
            Instantiate(nextPlayer, initialPosition, Quaternion.identity);
        } else {
            // TODO: GAME OVER
            Debug.Log("GAME OVER");
        }
    }
}