using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class LightTrailController : MonoBehaviour {

    public GameObject lightTrailPrefab;

    private static LightTrailController _instance;
    public static LightTrailController Instance { get { return _instance; } }

    private GameObject Target;
    private GameObject currentTrail;

    void Awake() {
        _instance = this;
    }

    public void TrackObject(GameObject target) {
        currentTrail = Instantiate(lightTrailPrefab, target.transform.position, Quaternion.identity);
        currentTrail.GetComponent<ParticleSystem>().Play();
        Target = target;
    }

    void Update() {
        if (Target != null)
        {
            currentTrail.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, -1);
        }
    }

}