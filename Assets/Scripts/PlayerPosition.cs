using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Transform player;

    public static PlayerPosition instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player != null)
        {
            CheckPoint();
        }
    }

    public void CheckPoint()
    {
        Vector3 playerPos = transform.position;
        playerPos.z = 0;

        player.position = playerPos;
    }
}
