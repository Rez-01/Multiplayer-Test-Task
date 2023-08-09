using UnityEngine;
using DG.Tweening;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Joystick _joystick;
    
    private Player _player;
    
    private PhotonView _view;
    
    private void Start()
    {
        _player = GetComponent<Player>();
        _joystick = FindObjectOfType<Joystick>();
        _view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!_view.IsMine) return;
        
        Vector3 currentPosition = _player.transform.position;

        float xMovement = currentPosition.x + _joystick.Horizontal;
        float yMovement = currentPosition.y + _joystick.Vertical;

        if (xMovement >= -8f && xMovement <= 8f && yMovement >= -4f
            && yMovement <= 4f)
        {
            _player.transform.DOMove(new Vector3(xMovement, yMovement, 0f), 1f);
        }

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _player.transform.DORotate(new Vector3(0f, 0f, -Mathf.Atan2(_joystick.Horizontal, 
                _joystick.Vertical) * Mathf.Rad2Deg), 1f);
        }
    }
}