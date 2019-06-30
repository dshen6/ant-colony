using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }
    const float REST_THRESHOLD = 0.25f;
    public float VELOCITY_DECAY = 0.90f;
    public Sprite[] RestSprites;
    public Sprite[] MoveSprites;
    public float MoveFramerate = 5;
    public float RestFramerate = 3;
    float mFrameCounter;
    public float MovementSpeed = 5;
    Vector3 mVelocity = Vector3.zero;
    Vector3 mFacingDirection = Vector3.left;
    private CharacterController mCharController;

    private SpriteRenderer mPlayerSprite;

    private State mCurrentState;

    private SpriteRenderer mLightSprite;

    public enum State
    {
        Resting,
        Moving,
    }

    void Awake() {
         mCharController = GetComponent<CharacterController>();
         mPlayerSprite = GetComponent<SpriteRenderer>();
         SpriteRenderer[] lightSources = GetComponentsInChildren<SpriteRenderer>();
         int selectedLightSource = (int) Random.Range(0.0f, 3.0f);
         Debug.Log(lightSources.Length);
         Debug.Log(selectedLightSource);
         for (int i = 1; i < lightSources.Length; i++) {
             if (i != selectedLightSource + 1) {
                 lightSources[i].enabled = false;
             }
         }
         mLightSprite = lightSources[selectedLightSource + 1];
         mLightSprite.enabled = true;
        if (_instance != this)
        {
            _instance = this;
        }
    }
    void Update() {
        if (mVelocity.magnitude < REST_THRESHOLD)
        {
            TransitionState(State.Resting);
        }

        mCharController.Move(mVelocity * Time.deltaTime);

        Sprite[] spriteArray = null;
        switch (mCurrentState)
        {
            case State.Moving:
                spriteArray = MoveSprites;
                mFrameCounter += MoveFramerate * (mVelocity.magnitude / MovementSpeed) * Time.deltaTime;
                break;

            case State.Resting:
                spriteArray = RestSprites;
                mFrameCounter += RestFramerate * Time.deltaTime;
                break;
        }
        
        if (spriteArray != null && spriteArray.Length > 0)
        {
            int frame = ((int)mFrameCounter) % spriteArray.Length;
            mPlayerSprite.sprite = spriteArray[frame];
        }

    }

    void FixedUpdate()
    {
        mVelocity *= VELOCITY_DECAY;
    }


    public void OnAxisInput(float horizontal, float vertical) {
        mVelocity += new Vector3(MovementSpeed * horizontal, MovementSpeed * vertical, 0);
        if (Mathf.Abs(horizontal) > .1f || Mathf.Abs(vertical) > .1f) {
            if (Mathf.Abs(horizontal) > .1f) {
                mFacingDirection = horizontal > 0 ? Vector3.right : Vector3.left;
            }
            TransitionState(State.Moving);
        }
        mPlayerSprite.flipX = mFacingDirection != Vector3.left;
        mLightSprite.flipX = mFacingDirection != Vector3.left;
    }

    public void OnAButton() {
        DialogueManager.Instance.DisplayNextSentence();
    }

    public void Die() {
        var deathPosition = this.transform.position;
        Destroy(this.gameObject);
        GameStateManager.Instance.OnDeath(deathPosition);
    }

    public void OnBButton() {
    }

    public void OnTriggerEnter(Collider other) {
        // MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
        // foreach(MonoBehaviour mb in list)
        // {
        // }
    }

    public void OnTriggerExit(Collider other) {
        // MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
        // foreach(MonoBehaviour mb in list)
        // {
        // }
    }
    void TransitionState(State state)
    {
        mCurrentState = state;
    }
}