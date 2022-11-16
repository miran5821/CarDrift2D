using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    [SerializeField] Transform player;
    [SerializeField] float speed;
   
    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
