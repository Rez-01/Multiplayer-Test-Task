using System;
using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerCounter : MonoBehaviour
{
    private int _counter;

    public static Action<int> OnCountChange;
    
    private PhotonView _view;

    private Hashtable _coins;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        
        _counter = 0;
        
        _coins = new Hashtable { { "Coins", 0 } };
        _view.Owner.CustomProperties = _coins;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Coin coin)) return;
        
        PhotonNetwork.Destroy(col.gameObject);

        if (!_view || !_view.IsMine || _view.Owner.CustomProperties["Coins"] == null) return;
        
        _counter++;

        _coins["Coins"] = _counter;
        _view.Owner.SetCustomProperties(_coins);
                
        OnCountChange?.Invoke(_counter);
    }
}
