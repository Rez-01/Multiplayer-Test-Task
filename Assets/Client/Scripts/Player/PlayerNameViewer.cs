using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNameViewer : MonoBehaviour
{
    private PhotonView _view;
    private TMP_Text _nameText;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _nameText = GetComponentInChildren<TMP_Text>();

        _nameText.text = _view.Owner.NickName;
    }
}
