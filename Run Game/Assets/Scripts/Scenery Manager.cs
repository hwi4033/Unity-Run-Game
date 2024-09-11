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
        // Color ���� ����
        // Color ������ ScreenImage color�� �����Ѵ�.
        Color color = screenImage.color;

        // Color.a ���� 1�� �����Ѵ�.
        color.a = 1f;

        // ScreenImage�� Ȱ��ȭ�Ѵ�.
        screenImage.gameObject.SetActive(true);

        // while���� color.a ���� 0���� ũ�ų� ���ٸ� �ݺ� �����Ѵ�.
        // screenImage�� color ���� ���� (yield return)
        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        // screenImage�� ��Ȱ��ȭ�Ѵ�.
        screenImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(int index)
    {
        // �񵿱� ����� scene �̵� - Coroutine �̿�
        screenImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        // <asyncOperation.allowSceneActivation>
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� �����̴�.
        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        // <asyncOperation.isDone>
        // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� �����̴�. (�б� ����)
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.Progress>
            // �۾��� ���� ���¸� ��Ÿ���� �����̴�. (�б� ����)
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
        // Fade In ȣ��
        Debug.Log("Fade In");

        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // private void Update()
    // {
    //     // ���� ����� scene �̵�
    //     // fake null�� ����ϱ� �ָ�?
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         SceneManager.LoadScene(1);
    //     }
    // }
}
