using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    [SerializeField] private GameObject text, drawer, note;
    [SerializeField] private AudioClip drawerClose;
    private PlayerInputHandler player;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerInputHandler>();
    }

    public GameObject GetDrawer
    {
        get { return drawer; }
    }

    public GameObject Text
    {
        get { return text; }
    }

    public void Exit()
    {
        drawer.SetActive(false);
        player.Sound.PlayOneShot(drawerClose);
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
