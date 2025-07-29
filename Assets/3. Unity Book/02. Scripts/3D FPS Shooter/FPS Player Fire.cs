using System.Collections;
using TMPro;
using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    #region 멤버변수
    private enum WeaponMode { Normal, Sniper }
    private WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    Animator anim;
    private ParticleSystem ps;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crosshair01;
    public GameObject crosshair02;
    public GameObject crosshair02_zoom;

    public GameObject weapon01_R;
    public GameObject weapon02_R;

    public float throwPower = 10f;
    public int weaponPower = 5;

    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    private bool zoomMode = false;
    #endregion

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }
    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        #region 마우스 왼쪽 클릭 -> 총발사
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("Move Motion") == 0)
                anim.SetTrigger("Attack");

            StartCoroutine(ShootEffectOn(0.05f));

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))//Raycast를 Enemy가 맞은경우
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else//Raycast를 맞은 대상이 Enemy가 아닌경우
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }
            }
        }

        #endregion

        #region 마우스 오른쪽 클릭 -> 일반모드-수류탄/저격모드-조준경
        if (Input.GetMouseButtonDown(1))
        {
            switch(wMode)
            {
                case WeaponMode.Normal://일반모드일때 마우스 오른쪽 -> 수류탄투척
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper://저격모드일때 마우스 오른쪽 -> 확대/축소 조준경
                    zoomMode = !zoomMode;//현재 줌모드 상태 변경

                    float fov = zoomMode ? 15f : 60f;
                    Camera.main.fieldOfView = fov;

                    crosshair02_zoom.SetActive(zoomMode);
                    crosshair02.SetActive(!zoomMode);


                    //if (!zoomMode)
                    //{
                    //    crosshair02_zoom.SetActive(true);
                    //    crosshair02.SetActive(false);
                    //}
                    //else
                    //{
                    //    crosshair02_zoom.SetActive(false);
                    //    crosshair02.SetActive(true);
                    //}



                    break;

                    //if (!zoomMode)
                    //{
                    //    Camera.main.fieldOfView = 15f;
                    //    zoomMode = true;
                    //}
                    //else
                    //{
                    //    Camera.main.fieldOfView = 60f;
                    //    zoomMode = false;
                    //}
            }

        }
        #endregion

        #region 무기변경
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";

            weapon01.SetActive(true);
            weapon02.SetActive(false);
            crosshair01.SetActive(true);
            crosshair02.SetActive(false);
            crosshair02_zoom.SetActive(false);
            weapon01_R.SetActive(true);
            weapon02_R.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";

            weapon01.SetActive(false);
            weapon02.SetActive(true);
            crosshair01.SetActive(false);
            crosshair02.SetActive(true);
            weapon01_R.SetActive(false);
            weapon02_R.SetActive(true);
        }
        #endregion
    }

    /// <summary>
    /// 총구 화염 이펙트
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator ShootEffectOn (float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
