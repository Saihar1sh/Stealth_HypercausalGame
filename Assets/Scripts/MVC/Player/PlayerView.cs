using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    private Rigidbody playerRb;

    private float mvtSpeed = 2f;

    private void Awake()
    {
        playerController = new PlayerController(this);
        playerRb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        playerRb.MovePosition(playerRb.position + InputManager.Instance.JoystickInput() * mvtSpeed * Time.deltaTime);
        Debug.Log(InputManager.Instance.JoystickInput());
    }
    public void GetPlayerController(PlayerController _playerController)
    {
        playerController = _playerController;
    }
}
