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
            FadeToLevel(1);
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
