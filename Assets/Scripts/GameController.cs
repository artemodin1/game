using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOver;

    private int point = 0;
    private Coroutine testCoroutine;

    // Start is called before the first frame update
    void Start() { testCoroutine = StartCoroutine(Points());}

    // Update is called once per frame
    void Update() { }
    private IEnumerator Points()
    {
        while (true)
        {
            point += 1;
            yield return new WaitForSeconds(1f);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 150, 70), "Очки: " + point.ToString());
    }
    public void Player_Died() => StartCoroutine(GameOver());

    private IEnumerator GameOver()
    {
        StopCoroutine(testCoroutine);
        _gameOver.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
}
