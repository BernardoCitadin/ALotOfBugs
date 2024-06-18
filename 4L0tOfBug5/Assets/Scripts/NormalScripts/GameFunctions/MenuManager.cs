using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    Animator anim;

    public void FadeIn()
    {
        anim.SetBool("FadeActv", true);
    }

    public void FadeOut()
    {
        anim.SetBool("FadeActiv", false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
