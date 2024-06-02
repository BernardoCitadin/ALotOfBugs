using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int hpToAdd;
    [SerializeField] int stghToAdd;
    [SerializeField] float atckSpdToAdd;
    [SerializeField] float spdToAdd;

    public GameObject Panel;
    public GameObject Pistol;

    public static Itens Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ItemActivate()
    {
        hpToAdd = Random.Range(5, 15);
        spdToAdd = Random.Range(0.3f, 0.6f);
        stghToAdd = Random.Range(1, 3);
        atckSpdToAdd = Random.Range(0.05f, 0.08f);
    }

    public void hpItem()
    {
        PlayerStats.Instance.lifeMax += hpToAdd;
        Gun.Instance.fireRate += atckSpdToAdd;
        Panel.SetActive(false);
    }

    public void atckSpdItem()
    {
        //Gun.Instance.fireRate -= atckSpdToAdd;
        Bullet.Instance.damage -= stghToAdd;

        Pistol.GetComponent<Gun>().fireRate -= atckSpdToAdd;

        Panel.SetActive(false);
    }
    public void stghItem()
    {
        Bullet.Instance.damage += stghToAdd;
        PlayerMovement.Instance.speed -= spdToAdd;
        Panel.SetActive(false);
    }

    public void spdItem()
    {
        PlayerMovement.Instance.speed += spdToAdd;
        PlayerStats.Instance.lifeMax -= hpToAdd;
        Panel.SetActive(false);
    }
}
