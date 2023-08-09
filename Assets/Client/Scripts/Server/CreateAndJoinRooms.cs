using Photon.Pun;
using TMPro;
using UnityEngine;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createInput;
    [SerializeField] private TMP_InputField _joinInput;

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(_createInput.text)) PhotonNetwork.CreateRoom(_createInput.text);
    }

    public void JoinRoom()
    {
        if (!string.IsNullOrEmpty(_joinInput.text)) PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
