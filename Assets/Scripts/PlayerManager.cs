using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CardManager cardManager;

    public float speed;
    private void Start()
    {

    }

    private void Update()
    {
        if (!cardManager.isCardActive)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                //animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                //animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                //animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                //animator.SetInteger("Direction", 0);
            }
            dir.Normalize();
            //animator.SetBool("isMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Transform child = collision.transform.GetChild(0).GetChild(0);

        if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("GravestoneB"))
        {
            child.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform child = collision.transform.GetChild(0).GetChild(0);

        if (collision.gameObject.CompareTag("GravestoneB"))
        {
            child.gameObject.SetActive(false);
        }
    }
}
