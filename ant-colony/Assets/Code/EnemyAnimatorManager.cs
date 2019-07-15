using UnityEngine;

[RequireComponent(typeof(ArrayAnimatorScript))]
public class EnemyAnimatorManager : MonoBehaviour 
{
    private static EnemyAnimatorManager _instance;
    public static EnemyAnimatorManager Instance { get { return _instance; } }

    public ArrayAnimatorScript EnemyHazardAnimation;

    void Awake() {
        if (_instance == null){
            _instance = this;
        }
        EnemyHazardAnimation = GetComponent<ArrayAnimatorScript>();
    }

    public void Play(Vector3 Position) {
        EnemyHazardAnimation.gameObject.transform.position = Position;
        EnemyHazardAnimation.Play();
    }
}