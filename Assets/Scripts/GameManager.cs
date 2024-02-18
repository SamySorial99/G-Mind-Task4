using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject LoadingScreen;
    public RawImage Image;
    private void Awake()
    {
        Instance = this;
        print("SHIT IS THIS IS NOT WORKING");

        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        print("THE ERROR WWAS HERE");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<AsyncOperation> ScenesLoading = new List<AsyncOperation>();

    public void LoadScreen()
    {
        LoadingScreen.SetActive(true);


        ScenesLoading.Add(SceneManager.UnloadSceneAsync(1));
        ScenesLoading.Add(SceneManager.LoadSceneAsync(2));


        StartCoroutine(GetSceneLoadingProgress());


    }
    
    public float totalSceneProgress = 0;

    public IEnumerator GetSceneLoadingProgress()
    {
        for(int i = 0; i < ScenesLoading.Count; i++)
        {
            while (!ScenesLoading[i].isDone)
            {

                foreach(AsyncOperation operation in ScenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress/ScenesLoading.Count)*100;

                Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, totalSceneProgress);
                yield return null;
            }
        }
        LoadingScreen.SetActive(false);
    }


}
