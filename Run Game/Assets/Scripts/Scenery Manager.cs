using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] Image screenImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator FadeIn()
    {
        // Color 변수 선언
        // Color 변수에 ScreenImage color를 저장한다.
        Color color = screenImage.color;

        // Color.a 값을 1로 설정한다.
        color.a = 1f;

        // ScreenImage를 활성화한다.
        screenImage.gameObject.SetActive(true);

        // while문을 color.a 값이 0보다 크거나 같다면 반복 수행한다.
        // screenImage의 color 값에 저장 (yield return)
        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        // screenImage를 비활성화한다.
        screenImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(int index)
    {
        // 비동기 방식의 scene 이동 - Coroutine 이용
        screenImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        // <asyncOperation.allowSceneActivation>
        // 장명이 준비된 즉시 장면이 활성화되는 것을 허용하는 변수이다.
        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        // <asyncOperation.isDone>
        // 해당 동작이 완료되었는지 나타내는 변수이다. (읽기 전용)
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.Progress>
            // 작업의 진행 상태를 나타내는 변수이다. (읽기 전용)
            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AsyncLoad(1));
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Fade In 호출
        Debug.Log("Fade In");

        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // private void Update()
    // {
    //     // 동기 방식의 scene 이동
    //     // fake null을 사용하기 애매?
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         SceneManager.LoadScene(1);
    //     }
    // }
}
