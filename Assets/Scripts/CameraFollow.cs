using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;

    private int cubeCount;
    private float initOffsetZ;

    private void Start()
    {
        //cubeCount =CubesManager.Instance.cubes.Count
        initOffsetZ = offset.z;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * 10f);

    }
    public void SetTargetPlayer(Transform t)
    {
        player = t;
    }
}
