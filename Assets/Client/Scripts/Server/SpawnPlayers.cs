using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;

    [Header("Spawn Range")] 
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private Hashtable _properties;
    private int _playerCount;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
        GameObject playerObject = PhotonNetwork.Instantiate(_playerPrefab.name, randomPos, Quaternion.identity);
        
        SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),
            Random.Range(0f, 1f));
    }
}
