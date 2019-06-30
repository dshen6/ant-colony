using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    private static HeartManager _instance;
    public static HeartManager Instance { get { return _instance; } }    
    
    public SpriteRenderer[] Hearts;

    public Sprite FullHeart;

    public Sprite EmptyHeart;

    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = Hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        if (_instance == null){
            _instance = this;
        }
    }

    public void LoseHealth() {
        if (Health > 0) {
            Hearts[Hearts.Length - Health].sprite = EmptyHeart;
            Health -= 1;
        }
    }
}
