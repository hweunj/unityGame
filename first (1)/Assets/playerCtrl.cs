using UnityEngine;
using System.Collections;

using UnityEngine.UI;
[System.Serializable]

public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;

    public Animation animation;
}

public class playerCtrl : MonoBehaviour
{
    MeshRenderer targetMR;
    float elapsed;

    public Anim anim;
    public Animation _animation;

    public float h = 0.0f;
    public float v = 0.0f;

    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 10.0f;

    public int hp = 100;                            // The amount of health the player starts the game with.
    public int initHp;                                   // The current health the player has.
    public Image imageHpbar;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.idle;
        _animation.Play();
        initHp = hp;
    }

    void Update()
    {
        var rotSpeed = 120;

        var amtRot = rotSpeed * Time.deltaTime; // 매 프레임 회전각도

        var angR = Input.GetAxis("Fire2"); //left alt
        var angL = Input.GetAxis("Fire1"); //left ctrl

        transform.Rotate(Vector3.up * angR * amtRot); //left alt를 누르면 오른쪽으로 회전
        transform.Rotate(Vector3.down * angL * amtRot); // left ctrl를 누르면 왼쪽으로 회전

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("H=" + h.ToString());
        Debug.Log("V=" + v.ToString());

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);
        //     tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));


        if (v >= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
            hp -= 20;
            imageHpbar.fillAmount = (float)hp / (float)initHp;
        }
        else if (v <= -0.1f) _animation.CrossFade(anim.runBackward.name, 0.3f);
        else if (h >= 0.1f) _animation.CrossFade(anim.runRight.name, 0.3f);
        else if (h <= -0.1f) _animation.CrossFade(anim.runLeft.name, 0.3f);
        else _animation.CrossFade(anim.idle.name, 0.3f);

        if (hp <= 0)
            playerdie();
    }

    void playerdie()
    {
//        transform.rotation = Quaternion.Euler(90, 0, 0);
        if (Time.time - elapsed >= 1)
        {
            targetMR.enabled = !targetMR.enabled;
            elapsed = Time.time;
        }

    }
}