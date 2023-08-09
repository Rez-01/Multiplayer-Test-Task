using System;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<Photon.Realtime.Player> OnGameOver;

    private void OnEnable()
    {
        PlayerHP.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        PlayerHP.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath(Photon.Realtime.Player player)
    {
        int alivePlayers = CheckAlivePlayers();
        if (alivePlayers == 1)
        {
            OnGameOver?.Invoke(GetAlivePlayer());
        }
    }

    private int CheckAlivePlayers()
    {
        int alive = 0;
        
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if ((bool)player.CustomProperties["Alive"]) alive++;
        }
        
        return alive;
    }

    private Photon.Realtime.Player GetAlivePlayer()
    {
        Photon.Realtime.Player alivePlayer = null;
        
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (!(bool)player.CustomProperties["Alive"]) continue;
            
            alivePlayer = player;
            break;
        }
        
        return alivePlayer;
    }
}