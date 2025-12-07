using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadStarterScene : MonoBehaviour
{
    public static LoadStarterScene instance;
    public string[] stages;
    public int currentStage = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(StartAnyStage());
    }

    public void StageFailed()
    {
        StartCoroutine(RewindStage());
    }

    public IEnumerator StartAnyStage()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(stages[currentStage], LoadSceneMode.Additive);
        SceneManager.LoadScene("Character Scene", LoadSceneMode.Additive);
    }

    public IEnumerator RewindStage()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync(stages[currentStage]);
        SceneManager.LoadScene(stages[currentStage], LoadSceneMode.Additive);
        StageReset();
    }
    public void StageCleared()
    {
        StartCoroutine(NextStage());
    }

    public IEnumerator NextStage()
    {
        yield return new WaitForSeconds(1f);
        yield return SceneManager.UnloadSceneAsync(stages[currentStage]);
        currentStage++;
        SceneManager.LoadScene(stages[currentStage], LoadSceneMode.Additive);
        if (currentStage != 5)
        {
            StageReset();
        }
        else
        {
            SceneManager.UnloadSceneAsync("Character Scene");
        }
    }
    public void StageReset()
    {
        SceneManager.UnloadSceneAsync("Character Scene");
        SceneManager.LoadScene("Character Scene", LoadSceneMode.Additive);
        BlackFadeClear.instance.FadeReset();
        BlackFadeFailed.instance.FadeReset();
    }
}
