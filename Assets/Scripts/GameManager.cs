using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject volumeTab;
    [SerializeField] private GameObject endGameTab;
    [SerializeField] private TextMeshProUGUI tmp;

    Draggable[] draggables;
    Animator[] cubesAnim;

    // Start is called before the first frame update
    void Start()
    {
        volumeTab.SetActive(false);
        if (SceneManager.GetActiveScene().name != "StartScreen")
            endGameTab.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartScreen")
        {
            cubesAnim = FindObjectsOfType<Animator>();
            if (cubesAnim.Length == 0)
            {
                volumeTab.SetActive(false);
                endGameTab.SetActive(true);
                tmp.text = "онаедю";
            }
        }
    }

    public void OpenVolumeTab()
    {
        if (SceneManager.GetActiveScene().name != "StartScreen")
        {
            if (!endGameTab.activeSelf)
            DisableAndEnableContorls(false);
        }
        volumeTab.SetActive(true);
    }

    public void CloseVolumeTab()
    {
        volumeTab.SetActive(false);
        if (SceneManager.GetActiveScene().name != "StartScreen")
        {
            DisableAndEnableContorls(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void RestartGame()
    {
        float musicVolume = PlayerPrefs.GetFloat("musicVolume");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        SceneManager.LoadScene("GameScene");
    }

    public void WinGame()
    {
        for (var i = 0; i < cubesAnim.Length; i++)
        {
            cubesAnim[i].Play("DestroyAnim");
        }

    }
    public void LoseGame()
    {
        volumeTab.SetActive(false);
        endGameTab.SetActive(true);
        tmp.text = "ньхайю";
    }

    public void DisableAndEnableContorls(bool bl)
    {
        draggables = FindObjectsOfType<Draggable>();
        for (var i = 0; i < draggables.Length; i++)
        {
            draggables[i].draggable = bl;
        }
    }
}
