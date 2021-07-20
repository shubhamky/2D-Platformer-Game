using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float speed;
    public float jump;
    bool crouch = false;

    private Rigidbody2D rb2d;
    void Awake()
    {
        Debug.Log("Script Attached");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
            animator.SetBool("Crouch", crouch);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            animator.SetBool("Crouch", crouch);
        }
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //Movement in horizontal direction
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Movement in vertical direction
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
