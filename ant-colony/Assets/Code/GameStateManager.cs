using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour 
{
    private static GameStateManager _instance;
    public static GameStateManager Instance { get { return _instance; } }

    public Vector3 initialPlayerPosition;

    public GameObject deadPlayerPrefab;

    public List<GameObject> playerPrefabs;

    public List<GameObject> winOverlays;

    public bool canRestart = false;

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
            return null;
        }
    }

    void Start() {
        Shuffle(playerPrefabs);
        SpawnPlayer();
        canRestart = false;
    }

    public void Win() {
        canRestart = true;
        foreach (GameObject overlay in winOverlays)
        {
            overlay.SetActive(true);
        };
    }

    void Shuffle(List<GameObject> objects)
	{
		// Loops through array
		for (int i = objects.Count-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			GameObject temp = objects[i];
			
			// Swap the new and old values
			objects[i] = objects[rnd];
			objects[rnd] = temp;
		}
	}

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnDeath(Vector3 deathPosition){
        Instantiate(deadPlayerPrefab, deathPosition, Quaternion.identity);
        HeartManager.Instance.LoseHealth();
        SpawnPlayer();
    }

    public void SpawnPlayer() {
        var nextPlayer = this.getNextPlayer();
        if (nextPlayer != null) {
            GameObject newPlayer = Instantiate(nextPlayer, initialPlayerPosition, Quaternion.identity);
            var tag = nextPlayer.GetComponent<PlayerController>().Tag;
            ProfileManager.Instance.ShowProfileForTag(tag);
            LightTrailController.Instance.TrackObject(newPlayer);
        } else {
            canRestart = true;
        }
    }
}