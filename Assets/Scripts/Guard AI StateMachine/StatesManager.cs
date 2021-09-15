using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    [SerializeField]
    private PlayerView player;

    private GuardView guardView;


    [SerializeField]
    private LayerMask obstaclesMask;

    [SerializeField]
    private Light spotLight;
    [SerializeField]
    private float viewDistance;
    [SerializeField]
    private float timeToSpotPlayer = .5f;
    private float viewAngle;
    private float playerVisibleTimer = 0f;


    private Color defaultSpotlightColor;

    private Vector3 lastDestinationPos;

    public bool obstaclesInMiddle = false;

    //states
    private WanderState wanderState;
    private ChaseState chaseState;
    private AttackState attackState;

    private GuardStateMachineBase currentState, previousState;


    private void Awake()
    {
        wanderState = GetComponent<WanderState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();
        guardView = GetComponent<GuardView>();
        defaultSpotlightColor = spotLight.color;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeStateTo(wanderState));
        viewAngle = spotLight.spotAngle;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerVisibiltyCheck();
        if (currentState != previousState)
            StartCoroutine(ChangeStateTo(currentState));

    }

    /*    public void AssignLastDestination(Vector3 lastDestPos)
        {
            lastDestinationPos = lastDestPos;
        }
    */
    private IEnumerator ChangeStateTo(GuardStateMachineBase newState)
    {
        if (currentState != null)
        {
            previousState = currentState;
            currentState.OnExitState();
            currentState = newState;
            currentState.OnEnterState();
        }
        else if (currentState == null)
        {
            currentState = newState;
            currentState.OnEnterState();
            previousState = currentState;
        }
        yield return null;
    }

    #region Player visibility
    private void PlayerVisibiltyCheck()
    {
        if (PlayerVisible())
        {
            playerVisibleTimer += Time.deltaTime;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotLight.color = Color.Lerp(defaultSpotlightColor, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
            currentState = attackState;

        else if (playerVisibleTimer >= timeToSpotPlayer / 2f)
            currentState = chaseState;

        else
            currentState = wanderState;
    }
    public bool PlayerVisible()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.transform.position, obstaclesMask))
                {
                    obstaclesInMiddle = false;
                    return true;
                }
                else
                {
                    obstaclesInMiddle = true;
                }

            }
        }
        return false;
    }
    #endregion
    public PlayerView GetPlayerRef()
    {
        return player;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
