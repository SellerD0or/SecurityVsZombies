using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAmount : MonoBehaviour
{
   [SerializeField] private GameObject _particle;
  [SerializeField] private int _extraBulletAmount = 15;

    public int ExtraBulletAmount { get => _extraBulletAmount; set => _extraBulletAmount = value; }

    public void Play()
   {
       _particle.SetActive(true);
       Destroy(gameObject);
   }
}
