using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    bool isPressedLeft = false, isPressedRight = false,dontPress;
    public float horizontal;


    public float speedZ;
    [SerializeField] float angle;
    [SerializeField] GameObject bombAnimation;
    [SerializeField] GameObject shieldActive;
    [SerializeField] GameObject oilStain;
    private void Awake()
    {
        Instance = this;

    }
    
    public void Left()
    {
        isPressedLeft = true;
    }
    public void Right()
    {
        isPressedRight = true;
    }
    public void Dont()
    {
        isPressedRight = isPressedLeft = false;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
#if UNITY_EDITOR
            horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.forward * -horizontal * angle * Time.deltaTime);
#endif

#if UNITY_ANDROID //&& !UNITY_EDITOR
            horizontal = isPressedLeft ? -1 : isPressedRight ? 1 : 0; 
            transform.Rotate(Vector3.forward * -horizontal * angle * Time.deltaTime);

#endif

            transform.Translate(Vector3.up * speedZ * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            GameObject effect = Instantiate(bombAnimation, this.gameObject.transform);
            Destroy(effect, 1f);
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject.CompareTag("Barrier"))
        {
            GameManager.Instance.GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreManager.Instance.coin += 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(ShieldActive());
        }
        if (collision.gameObject.CompareTag("Oil"))
        {
            collision.gameObject.SetActive(false);
            GameObject oil = Instantiate(oilStain, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(oil, 5f);
        }
        if (collision.gameObject.CompareTag("Nitro"))
        {
            StartCoroutine(NitroActive());
        }
    }
   
    IEnumerator NitroActive()
    {
        speedZ *= 2;
        yield return new WaitForSeconds(3f);
        speedZ /= 2;
    }
    IEnumerator ShieldActive()
    {
        shieldActive.SetActive(true);
        yield return new WaitForSeconds(5f);
        shieldActive.SetActive(false);
    }
}
