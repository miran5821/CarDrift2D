using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    Transform player;
    [SerializeField] float followSpeed;
    [SerializeField] GameObject bombAnimation;
    float offset;
    private void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").transform;
        offset = -90;
    }
    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0), followSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,0), followSpeed * Time.deltaTime);
        Vector3 difference = player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + offset);




        if (!GameManager.Instance.isGameStarted)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stain"))
        {
            followSpeed = 4;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stain"))
        {
            followSpeed = 9;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            GameObject effect = Instantiate(bombAnimation, collision.gameObject.transform);
            StartCoroutine(ObjectEnabled(0.3f));

        }
        if (collision.gameObject.CompareTag("Barrier"))
        {
            GameObject effect = Instantiate(bombAnimation, collision.gameObject.transform);
            StartCoroutine(ObjectEnabled(0.3f));
        }
        if (collision.gameObject.CompareTag("ShieldActive"))
        {
            GameObject effect = Instantiate(bombAnimation,collision.transform);
            Destroy(effect, .4f);
            //StartCoroutine(ObjectEnabled(0.5f));
            gameObject.SetActive(false);
        }
    }
    
    
    IEnumerator ObjectEnabled(float second)
    {
        yield return new WaitForSeconds(second);
        gameObject.SetActive(false);
    }
}
