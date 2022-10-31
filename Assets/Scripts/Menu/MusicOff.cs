using UnityEngine;

public class MusicOff : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject text;

    private TextMesh _tm;
    private int musicState = 0;
    private void Start()
    {
        _tm = text.GetComponent<TextMesh>();

        // 0 - music on effects on
        if (PlayerPrefs.GetString("Music") == "On" &&
            PlayerPrefs.GetString("EffectsSound") == "On")
        {
            musicState = 0;
            _tm.text = "Music - On\r\nEffects - On";
            gameManager.GetComponent<AudioSource>().Play();
        }

        // 1 - music off effects on
        if (PlayerPrefs.GetString("Music") == "Off" &&
            PlayerPrefs.GetString("EffectsSound") == "On")
        {
            musicState = 1;
            _tm.text = "Music - Off\r\nEffects - On";
            gameManager.GetComponent<AudioSource>().Stop();
        }

        // 2 - music on effects off
        if (PlayerPrefs.GetString("Music") == "On" &&
            PlayerPrefs.GetString("EffectsSound") == "Off")
        {
            musicState = 2;
            _tm.text = "Music - On\r\nEffects - Off";
            gameManager.GetComponent<AudioSource>().Play();
        }

        // 3 - music off effect off
        if (PlayerPrefs.GetString("Music") == "Off" &&
            PlayerPrefs.GetString("EffectsSound") == "Off")
        {
            musicState = 3;
            _tm.text = "Music - Off\r\nEffects - Off";
            gameManager.GetComponent<AudioSource>().Stop();
        }
    }
    public void musicOffOn()
    {
        musicState++;
        if (musicState > 3)
            musicState = 0;

        switch (musicState)
        {
            case 0:
                PlayerPrefs.SetString("Music", "On");
                PlayerPrefs.SetString("EffectsSound", "On");
                _tm.text = "Music - On\r\nEffects - On";
                gameManager.GetComponent<AudioSource>().Play();
                break;
            case 1:
                PlayerPrefs.SetString("Music", "Off");
                PlayerPrefs.SetString("EffectsSound", "On");
                _tm.text = "Music - Off\r\nEffects - On";
                gameManager.GetComponent<AudioSource>().Stop();
                break;
            case 2:
                PlayerPrefs.SetString("Music", "On");
                PlayerPrefs.SetString("EffectsSound", "Off");
                _tm.text = "Music - On\r\nEffects - Off";
                gameManager.GetComponent<AudioSource>().Play();
                break;
            case 3:
                PlayerPrefs.SetString("Music", "Off");
                PlayerPrefs.SetString("EffectsSound", "Off");
                _tm.text = "Music - Off\r\nEffects - Off";
                gameManager.GetComponent<AudioSource>().Stop();
                break;
            default:
                break;
        }
    }
}
