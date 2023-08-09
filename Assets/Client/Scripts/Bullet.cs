using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Player player)) return;
        
        if (_view && !_view.IsMine)
        {
            player.HP.OnTakeDMG(_damage);
        }
    }
}
