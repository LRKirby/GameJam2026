using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    [SerializeField] private GameObject text, drawer, note;
    private PlayerInputHandler player;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerInputHandler>();
    }

    public GameObject GetDrawer
    {
        get { return drawer; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }

    public void Exit()
    {
        drawer.SetActive(false);
        player.Open = false;
        Time.timeScale = 1;
    }

    public void Note()
    {
        note.SetActive(true);
    }

    public void NoteBack()
    {
        note.SetActive(false);
    }
}
