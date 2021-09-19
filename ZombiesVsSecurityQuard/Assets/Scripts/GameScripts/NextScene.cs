using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{

    private void OnEnable() {
        Time.timeScale = 1;
    }
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Text _text;
    [SerializeField] private Timer _timer;
   public void LoadGame()
   {
       SceneManager.LoadScene(1);
   }
   public void Exit() {
       SceneManager.LoadScene(0);
   }
   public void EndGame()
   {

       _loseScreen.SetActive(true);
       Time.timeScale = 0;
       _text.text =  "Поздравляю, вы продержались: " + _timer.Hours + " : " + _timer.Seconds.ToString();
   }
}
