using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _heart;
    private float _fillValue;
    [SerializeField] private Player _player;
  public void ChangeHealth()
  {
    Debug.Log("ChangeHealth");
      _fillValue = (float) _player.Health;
        _fillValue = _fillValue / _player.MaxHealth;
        _heart.fillAmount = _fillValue;
  }
}
