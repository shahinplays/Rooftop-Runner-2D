using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask groundLayer;
    public int extraJump;

    public Animator[] modelAnim;
    public GameObject[] characterSkins;
    public int currentIndex;


    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("SelectCharacter");

        foreach (GameObject skin in characterSkins)
        {
            skin.gameObject.SetActive(false);
        }
        characterSkins[currentIndex].SetActive(true);
        
        modelAnim[currentIndex].gameObject.GetComponent<Animator>();
       
        
        AudioManager.instance.StopSound("IntroMusic");
        AudioManager.instance.PlaySound("GameMusic");

    }






    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        PlayerMobileJump();

        modelAnim[currentIndex].SetBool("isGrounded", isGrounded);




    }



    private void FixedUpdate()
    {
        if (transform.position.x <= -30f || transform.position.y <= -20f)
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.PlayerGetDamage(1);
                transform.position = new Vector3(-8, 16, 0);
            }
        }
    }





    private void PlayerMobileJump()
    {
        if (isGrounded) { extraJump = 1; }

        if (Input.GetMouseButtonDown(0) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            AudioManager.instance.PlaySound("JumpMusic");
        }
        if(Input.GetMouseButtonDown(0) && extraJump == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.PlaySound("JumpMusic");
        }
    }



    /*
    public void PlayerJump()
    {
        if (isGrounded) { extraJump = 1; }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            AudioManager.instance.PlaySound("JumpMusic");            
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.PlaySound("JumpMusic");
        }
    }

    */





}
