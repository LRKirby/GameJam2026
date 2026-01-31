using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    [SerializeField] private GameObject text, drawer;

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
}
