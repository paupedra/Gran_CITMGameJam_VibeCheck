using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Changer : MonoBehaviour
{
    public Animator animator;

    private int levelToLoadIndex;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            FadeToLevel(0);
        }
    }

    public void FadeToLevel(int levelIndex)
    {   
        levelToLoadIndex = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoadIndex);
    }



}
