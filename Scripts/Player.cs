using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float idleSpeed;
    public float swimSpeed, onBonusSpeed;
    float speed;
    public float jumpHeight;
    public Transform groundCheck;
    bool isGrounded;
    Animator anim;
    int curHP;
    int maxHP = 3;
    bool isHit = false;
    bool canHit = true;
    bool isBonusesSpeed;
    float onHitDelay = 0.01f;
    public Main main;
    public bool haveKey = false;
    public bool isDoorWait = false;
    public bool isSwim;
    bool climb = false;
    public int coins = 0;
    public GameObject speedHUD, unhitHUD;
    public float bonusCooldown;
    SoundEffector se;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        se = GetComponent<SoundEffector>();
        speed = idleSpeed;

        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        CheckGround();

        CheckJump();

        updateAnimation();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);

        int enemys = 0;

        foreach (Collider2D coll in colliders)
        {
            if (coll.tag == "Enemy" || coll.tag == "LadderDown")
            {
                enemys = 100;
            }
        }

        isGrounded = colliders.Length - enemys > 1;
    }

    void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !climb)
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    void updateAnimation()
    {
        if (isSwim) {
            speed = swimSpeed;
            anim.SetInteger("State", 4);
        }

        else if (climb)
        {
            anim.SetInteger("State", 5);
        }

        else if (Input.GetAxis("Horizontal") == 0)
            anim.SetInteger("State", 1);

        else
        {
            if (!isGrounded)
            {
                anim.SetInteger("State", 2);
            }

            else
            {
                if (isBonusesSpeed)
                    speed = onBonusSpeed;
                else
                    speed = idleSpeed;
                    
                anim.SetInteger("State", 3);
            }

        }
    }

    public void RecountHP(int deltaHP)
    {

        if (deltaHP < 0 && canHit)
        {
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }

        if (deltaHP + curHP <= maxHP && canHit)
        {
            curHP += deltaHP;
        }

        if (curHP <= 0)
        {
            death();
            Invoke("Lose", 1.5f);
            se.playLose();
        }
    }

    void death()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    IEnumerator OnHit()
    {
        SpriteRenderer color = GetComponent<SpriteRenderer>();

        if (isHit)
            color.color = new Color(1f, color.color.g - onHitDelay, color.color.b - onHitDelay);
        else
            color.color = new Color(1f, color.color.g + onHitDelay, color.color.b + onHitDelay);

        if (color.color.b == 1f)
            StopCoroutine(OnHit());

        if (color.color.g <= 0)
        {
            isHit = false;
        }

        yield return new WaitForSeconds(onHitDelay);
        StartCoroutine(OnHit());
    }

    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            haveKey = true;
        }

        if (collision.gameObject.tag == "Coin")
        {
            se.playCoinTake();
        }

        if (collision.gameObject.tag == "Win")
        {
            se.playWin();
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ladder")
        {

            climb = true;

            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * speed * 0.5f);

        }

        else if (Input.GetKey(KeyCode.E))
        {

            if (collision.gameObject.tag == "Door")
            {
                door fromDoor = collision.GetComponent<door>();

                if (!fromDoor.isOpen && haveKey)
                {
                    fromDoor.Unlock();

                    haveKey = false;
                }

                else if (fromDoor.isOpen)
                {
                    if (!isDoorWait)
                    {
                        fromDoor.Teleport();
                    }
                }
            }
        }
    }


    public int getCoins()
    {
        return coins;
    }

    public int getHP()
    {
        return curHP;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            climb = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void addHealthEffect()
    {
        RecountHP(1);
    }

    public void addSpeedEffect() {
        StartCoroutine(StartSpeedBonus());
    }


    IEnumerator StartSpeedBonus()
    {
        speedHUD.SetActive(true);
        isBonusesSpeed = true;

        yield return new WaitForSeconds(bonusCooldown);

        isBonusesSpeed = false;
        speedHUD.SetActive(false);
    }

    public void addUnhitEffect()
    {
        StartCoroutine(StartUnhitBonus());
    }


    IEnumerator StartUnhitBonus()
    {
        unhitHUD.SetActive(true);
        canHit = false;

        yield return new WaitForSeconds(bonusCooldown);

        canHit = true;
        unhitHUD.SetActive(false);
    }

}
