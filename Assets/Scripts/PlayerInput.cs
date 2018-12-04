using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        float horizontal = 0;
        if (InputManager.I.GoingLeft()) horizontal -= 1;
        if (InputManager.I.GoingRight()) horizontal += 1;
        
        Vector2 directionalInput = new Vector2(horizontal, 0f);
        player.SetDirectionalInput(directionalInput);

        if (InputManager.I.Jumped())
        {
            player.OnJumpInputDown();
        }
        if (InputManager.I.StoppedJumping())
        {
            player.OnJumpInputUp();
        }
    }
}
