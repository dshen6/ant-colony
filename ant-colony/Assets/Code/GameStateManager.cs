using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    private static GameStateManager _instance;
    public static GameStateManager Instance { get { return _instance; } }

    public Vector3 initialPosition;

    // TODO: this will probably need to be a list of deadplayerprefabs and their dead positions
    public GameObject deadplayerPrefab;
    public GameObject playerPrefab;

    void Awake() {
        if (_instance == null){
            _instance = this;
        }
    }

    public void OnDeath(Vector3 deathPosition){
        Instantiate(deadplayerPrefab, deathPosition, Quaternion.identity);
        Instantiate(playerPrefab, initialPosition, Quaternion.identity);
    }
}