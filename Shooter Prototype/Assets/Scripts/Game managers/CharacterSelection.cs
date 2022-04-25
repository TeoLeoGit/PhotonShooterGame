using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CharacterSelection : MonoBehaviourPunCallbacks
{
    public GameObject[] characters;
    public int selectedCharacterIndex = 0;
    public GameObject spawner;
    public GameObject selector;
    public GameObject startCamera;
    // Start is called before the first frame update
    public void NextCharacter()
    {
        characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex = (selectedCharacterIndex + 1) % characters.Length;
        characters[selectedCharacterIndex].SetActive(true);

    }

    public void PreviousCharacter()
    {
        characters[selectedCharacterIndex].SetActive(false);
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex += characters.Length;
        }
        characters[selectedCharacterIndex].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacterIndex", selectedCharacterIndex);
        spawner.SetActive(true);
        selector.SetActive(false);
        startCamera.SetActive(false);
    }
}
