using UnityEngine;

public class ProfileManager : MonoBehaviour 
{
    private static ProfileManager _instance;

    public static ProfileManager Instance { get { return _instance; } }


    public string customText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void onGUI()
    {
        // Make a text field that modifies stringToEdit.
        customText = GUI.TextField(new Rect(0, 0, 200, 20), customText, 25);
 
    }


}