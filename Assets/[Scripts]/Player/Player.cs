using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject lightObj, jumpscare, mask;
    [SerializeField] private BatteryUI hudGameObject;
    [SerializeField] private AudioClip scareAudio;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject[] faces;
    private Rigidbody2D rBody;
    private PlayerInputHandler input;
    private float xVelocity;
    private float yVelocity;
    private Animator anim;
    private Vector2 mouse, lightRotation;
    private AudioClip[] footsteps;
    private AudioSource noise;
    private bool stepped;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        anim = GetComponent<Animator>();
        footsteps = new AudioClip[4];
        noise = GetComponent<AudioSource>();

        // add every footstep sound to an array
        for (int i = 0; i < 4; i++)
        {
            footsteps[i] = Resources.Load<AudioClip>($"Audio/step{i + 1}");
        }
    }

    void Update()
    {
        if (rBody.linearVelocity.x != 0 || rBody.linearVelocity.y != 0)
        {
            anim.SetBool("Walking", true);
            // footstep sounds
            if (!stepped)
            {
                // get a random footstep sound
                int randomSound = UnityEngine.Random.Range(0, footsteps.Length);
                // play it
                noise.PlayOneShot(footsteps[randomSound]);
                stepped = true;
                // time between steps
                StartCoroutine(Footstep());
            }
        }
        else
            anim.SetBool("Walking", false);

        // get the mouse location on the screen
        mouse = Mouse.current.position.ReadValue();
        // find the middle of the screen
        // if the mouse is on the left, turn left
        if (mouse.x < Screen.width / 2)
        {
            LightFlip();
            anim.SetBool("FacingRight", false);
        }
        // if the mouse is on the right, turn right
        if (mouse.x > Screen.width / 2)
        {
            LightFlip();
            anim.SetBool("FacingRight", true);
        }

        if (input.FlashlightOn && hudGameObject.flashlightDead == false)
        {
            lightObj.SetActive(true);
        }
        else
        {
            lightObj.SetActive(false);
        }
    }

    private void LightFlip()
    {
        lightRotation = lightObj.transform.localScale;
        if (anim.GetBool("FacingRight"))
            lightRotation.y = 1;
        else
            lightRotation.y = -1;
        lightObj.transform.localScale = lightRotation;
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        xVelocity = input.MoveInput.x * moveSpeed;
        yVelocity = input.MoveInput.y * moveSpeed;
        rBody.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!jumpscare.activeSelf)
            {
                jumpscare.SetActive(true);
                faces[Random.Range(0, faces.Length)].SetActive(true);
                music.Stop();
                noise.PlayOneShot(scareAudio);
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3.25f);
        SceneManager.LoadScene(1);
    }

    IEnumerator Footstep()
    {
        yield return new WaitForSeconds(0.6f);
        stepped = false;
    }
}

