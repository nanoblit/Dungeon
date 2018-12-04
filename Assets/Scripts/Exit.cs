using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_playerLayerMask | (1 << collision.gameObject.layer)) == _playerLayerMask)
        {
            Debug.Log(collision.gameObject.layer);
            GameManager.I.NextLevel();
        }
    }
}
