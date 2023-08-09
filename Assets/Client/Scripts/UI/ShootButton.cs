using System;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public static Action OnShootButton;

    public void OnShoot()
    {
        OnShootButton?.Invoke();
    }
}
