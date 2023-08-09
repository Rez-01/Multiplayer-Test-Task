using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public void OnLobby()
    {
        if (string.IsNullOrEmpty(_inputField.text)) return;
        
        PhotonNetwork.NickName = _inputField.text;
        SceneManager.LoadScene("Loading");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
