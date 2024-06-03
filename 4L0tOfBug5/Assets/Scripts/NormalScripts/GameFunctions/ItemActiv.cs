using UnityEngine;

public class ItemActiv : MonoBehaviour
{
    public GameObject Panel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crate"))
        {
            Panel.SetActive(true);
            Destroy(collision.gameObject);
            Itens.Instance.ItemActivate();
        }
    }
}
