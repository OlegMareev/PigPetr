using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstOpen : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetString("FirstOpen") != "No")
        {
            PlayerPrefs.SetInt("CoinValue", 0);
            PlayerPrefs.SetString("LastScene", "Tutorial");
            PlayerPrefs.SetString("Music", "On");
            PlayerPrefs.SetString("EffectsSound", "On");

            PlayerPrefs.SetString("FirstOpen", "No");
        }
        
    }
}
