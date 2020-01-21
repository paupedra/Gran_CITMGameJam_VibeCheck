using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Changer : MonoBehaviour
{
    public Animator animator;

    private int levelToLoadIndex;

    private int firstLevelIndex     = 0;
    private int secondLevelIndex    = 1;
    private int thirdLevelIndex     = 2;
    private int first_test_Index    = 3;
    private int second_test_Index   = 4;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            FadeToNextLevel();
        }

        GoToLevel();
    }

    public void FadeToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 3)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            FadeToLevel(0);
        }
    }

    public void GoToLevel()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            FadeToLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            FadeToLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            FadeToLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            FadeToLevel(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            FadeToLevel(4);
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