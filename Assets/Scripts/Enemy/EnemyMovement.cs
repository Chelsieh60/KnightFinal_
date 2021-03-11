using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 roampos;
    private EnemyMovement pathFinding;
    private void Awake(){
        pathFinding = GetComponent<EnemyMovement>();
    }
  private void Start(){
      startPos = transform.position;
      roampos = GetRommPos();
  }
  private void Update(){
      pathFinding.transform.Translate(roampos);
      if (Vector3.Distance(transform.position, roampos) < 1){

      }
  }
  public static Vector3 GetRandom(){
      return new Vector3(UnityEngine.Random.Range(-1,1), UnityEngine.Random.Range(-1,1)).normalized;
  }
  private Vector3 GetRommPos(){
      return startPos + EnemyMovement.GetRandom() * Random.Range(1f,2f);
  }
}
