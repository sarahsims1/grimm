using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    public Image loadScreen;
    public LineRenderer lr;
    public Slider slidy;
    private Color color;
    private string level;

    private bool loading;
    private bool fadeIn;
    public float fadeSpeed = 1f;

    private void Start()
    {
        color = loadScreen.color;
        color.a = 0;
        loadScreen.color = color;
    }
    public void Load(string level)
    {
        StartCoroutine(LoadAsync(level));
        lr.enabled = false;
        loadScreen.gameObject.SetActive(true);
        slidy.gameObject.SetActive(true);
        fadeIn = true;
    }

    private void Update()
    {
        if(fadeIn)
        {
            color.a += fadeSpeed * Time.deltaTime;
            loadScreen.color = color;
        }
        if(loading)
        { 
            AsyncOperation operation = SceneManager.LoadSceneAsync(level);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slidy.value = progress;
        }
    }

    IEnumerator LoadAsync(string level)
    {
        yield return new WaitUntil(() => loadScreen.color.a > 0.99f);
        this.level = level;
        loading = true;
    }
}
