using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    private Rigidbody playerRb;

    private float mvtSpeed = 8f, playerKillCooldownTime;

    private float health, maxHealth = 10;

    private Collider[] enemiesInKillRange;
    private HealthBar healthBar;
    private bool enemiesDetected, playerKillCooldownBool = true;

    [SerializeField]
    private float killDist;
    [SerializeField]
    private LayerMask enemiesMask;

    private void Awake()
    {
        playerController = new PlayerController(this);
        playerRb = GetComponent<Rigidbody>();
        healthBar = GetComponent<HealthBar>();
        health = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        EnemyDetection();
    }

    private void EnemyDetection()
    {
        enemiesDetected = Physics.CheckSphere(transform.position, killDist, enemiesMask);
        enemiesInKillRange = Physics.OverlapSphere(transform.position, killDist, enemiesMask);
        if (enemiesDetected)
            KillEnemy(enemiesInKillRange[0].GetComponent<GuardView>());
    }

    private void KillEnemy(GuardView guard)
    {
        if (playerKillCooldownBool)
            StartCoroutine(KillCoolDown(guard, playerKillCooldownTime));
    }

    public void ModifyHealth(float amt)
    {
        health += amt;
        if (health < 0)
        {
            health = 0;
            //death

        }
        healthBar.SetHealth(health);
    }

    private void UpdateMovement()
    {
        playerRb.MovePosition(playerRb.position + InputManager.Instance.JoystickInput() * mvtSpeed * Time.deltaTime);

    }
    public void GetPlayerController(PlayerController _playerController)
    {
        playerController = _playerController;
    }

    IEnumerator KillCoolDown(GuardView guard, float time)
    {
        playerKillCooldownBool = false;
        yield return new WaitForSeconds(time);
        guard.ModifyHealth(-1);
        playerKillCooldownBool = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, killDist);
    }
}
