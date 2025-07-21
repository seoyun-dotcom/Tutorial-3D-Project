using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    ///화살을 발사하는 기능
    /// - 화살
    /// - 발사할 위치
    /// - 화살이 날라가는기능

    public GameObject arrowPrefab;
    public Transform shootTf;
    public bool isShoot;

    ///누군가를 감지하는기능
    /// - 직선상으로 감지
    /// - 감지했을때 화살을 생성
    /// - 생성한 화살이 날라감

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;//레이저에 닿은 대상

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootTf.position, shootTf.forward * 100f, Color.green);

        if (isTargeting && !isShoot)
        {
            //화살 생성
            //화살 위치 설정

            StartCoroutine(ShootRoutine());

        }

        //if(Physics.Raycast(ray, out hit))
        //{

        //}
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootTf.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootTf.position, shootTf.forward * 100f);
    }
}
