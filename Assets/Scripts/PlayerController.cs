using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform center_pos;
    [SerializeField] Transform left_pos;
    [SerializeField] Transform right_pos;
    [SerializeField] Rigidbody rb;

    int current_pos = 0;

    public float side_speed;
    public float running_speed;
    public float jump_force;

    bool isGameStarted = false;
    bool isGameOver = false;


    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        current_pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted || !isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game is started");
                isGameStarted = true;
                playerAnimator.SetInteger("isRunning", 1);
                playerAnimator.speed = 1.3f;
            }
        }

        if (isGameStarted) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + running_speed * Time.deltaTime);

            if (current_pos == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 2;
                }

            }
            else if (current_pos == 1)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 0;
                }
            }
            else if (current_pos == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 0;
                }
            }

            if (current_pos == 0)
            {
                if (Vector3.Distance(transform.position, new Vector3(center_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(center_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }
            else if (current_pos == 1)
            {
                if (Vector3.Distance(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(left_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }
            else if (current_pos == 2)
            {
                if (Vector3.Distance(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(right_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                    transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * jump_force;
                StartCoroutine(Jump());
            }
        }
    }

    IEnumerator Jump()
    {
        playerAnimator.SetInteger("isJumping", 1);
        yield return new WaitForSeconds(0.1f);
        playerAnimator.SetInteger("isJumping", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "object")
        {
            isGameStarted = false;
            isGameOver = true;
            playerAnimator.applyRootMotion = true;
            playerAnimator.SetInteger("isDead", 1);
        }
    }
}
