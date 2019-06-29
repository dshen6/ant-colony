using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    private static GameStateManager _instance;
    public static GameStateManager Instance { get { return _instance; } }

    public Vector3 initialPosition;

    public GameObject playerPrefab;    

    void Awake() {
        if (_instance == null){
            _instance = this;
        }
    }

    public void OnDeath(){
        Instantiate(playerPrefab, initialPosition, Quaternion.identity);
    }
}