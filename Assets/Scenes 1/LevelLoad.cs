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
    int counter = 0;

    private bool loading;

    private void Awake()
    {     
        loading = false;
        lr.enabled = true;
        loadScreen.gameObject.SetActive(false);
        slidy.gameObject.SetActive(false);
        color = loadScreen.color;
    }
    public void Load(string level)
    {
        this.level = level;
        lr.enabled = false;
        loadScreen.gameObject.SetActive(true);
        slidy.gameObject.SetActive(true);
        loading = true;
        color.a = 1f;
        loadScreen.color = color;
    }

    private void Update()
    {
        if(loading && counter == 0)
        { 
            AsyncOperation operation = SceneManager.LoadSceneAsync(level);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slidy.value = progress;
            counter++;
        }
    }
}
