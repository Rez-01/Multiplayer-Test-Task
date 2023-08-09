using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int _currentHP;
    private Player _player;

    public static Action<int> OnHPChange;
    public static Action<int> SetMaxHP;
    public static Action<Photon.Realtime.Player> OnPlayerDeath;
    public Action<int> OnTakeDMG;

    private PhotonView _view;

    private Hashtable _alive;

    private void OnEnable()
    {
        OnTakeDMG += ApplyDamage;
    }

    private void OnDisable()
    {
        OnTakeDMG -= ApplyDamage;
    }

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _player = GetComponent<Player>();
        _currentHP = _maxHP;
        SetMaxHP?.Invoke(_maxHP);
        
        _alive = _view.Owner.CustomProperties;
        
        _alive.Add("Alive", true);

        _view.Owner.CustomProperties = _alive;
    }

    private void ApplyDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            OnHPChange?.Invoke(_currentHP);

            _alive["Alive"] = false;
            _view.Owner.CustomProperties = _alive;
            
            PhotonNetwork.Destroy(_player.gameObject);
            OnPlayerDeath?.Invoke(_view.Owner);
        }
        
        OnHPChange?.Invoke(_currentHP);
    }
}
