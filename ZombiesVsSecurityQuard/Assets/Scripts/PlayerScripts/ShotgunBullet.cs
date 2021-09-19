using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    private int _angle;

   private void Start() {
       StartCoroutine(Shoot());
   }
   private IEnumerator Shoot()
   {
       
       yield return new WaitForSeconds(2);
       transform.position = new Vector2(Rotate(), Rotate());
   }
   private int Rotate()
   {
      return  _angle = Random.Range(1, 10);
   }
}
