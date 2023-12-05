using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(player, speed);
    }

    private void MoveForward(Transform player, float speed = 10.0f)
    {
        player.Translate(player.forward * speed * Time.deltaTime);
    }
}
