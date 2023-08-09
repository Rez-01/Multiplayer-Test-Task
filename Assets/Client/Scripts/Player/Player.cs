using System;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPositionTransform;

    private PhotonView _view;

    private bool _canShoot;

    public PlayerHP HP;

    private void OnEnable()
    {
        ShootButton.OnShootButton += InstantiateBullet;
    }

    private void OnDisable()
    {
        ShootButton.OnShootButton -= InstantiateBullet;
    }

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void InstantiateBullet()
    {
        if (!_view.IsMine) return;
        
        GameObject gameObject = PhotonNetwork.Instantiate(_bulletPrefab.name, new Vector3(
                _spawnPositionTransform.position.x,
                _spawnPositionTransform.position.y,
                0f),
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));

        Bullet bullet = gameObject.GetComponent<Bullet>();

        bullet.gameObject.GetComponent<Rigidbody2D>()
            .AddForce(_spawnPositionTransform.up * 2f, ForceMode2D.Impulse);
    }
}
