using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test_Smoke : MonoBehaviour
{
    public Button[] interaction_button = new Button[3];
    public GameObject guidance_text;
    public Test_jun camera_jun;
    bool button_start = false;
    public float time;
    [Header("줌인 혹은 줌아웃 대기시간")]
    public float dealay_time;
    [Header("확대")]
    public float zoom_in;
    [Header("축소")]
    public float zoom_out;
    int zoom_base = 10;
    [Header("축소 확대 속도")]
    public float zoom_speed;
    public GameObject[] elements = new GameObject[3];
    public GameObject target;
    Vector3 target_pos;
    float size = 0;
    [Header("목표물을 쳐다보는 속도로 높을 수록 빠르게 봄")]
    public float focusing_speed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < interaction_button.Length; i++)
        {
            interaction_button[i].interactable = false;
        }
        interaction_button[1].interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        //반딧불이가 다 말한 후에 텍스트 게임오브젝트 활성화 시키기
        //첫번째로 연료를 눌러보세요 -> 산소를 눌러보세요 -> 점화원을 눌러보세요
        //아랫부분 나중에 바꾸기
        if (time > 5)
        {
            //JUNHEE_PLMING : 여기 나중에 반딧불이 말한 후에 텍스트 등장하는 로직으로 바꾸기
            guidance_text.SetActive(true);
        }
        else
        {
            time += Time.deltaTime;
        }
        if (button_start)
        {
            //size = Mathf.Clamp(size + Time.deltaTime * focusing_speed, 0, 1);
            //지금 스무스하게 회전값을 주면서 타겟을 바라보는 로직 만드는중
            /*if(target_pos == Vector3.zero)
            {
                target_pos = target.transform.position - transform.position;
            }*/
            camera_jun.transform.rotation = Quaternion.Lerp(camera_jun.transform.rotation, Quaternion.LookRotation(target.transform.position - camera_jun.transform.position), 1 * Time.deltaTime * focusing_speed);
            //transform.LookAt(target.transform);
            //camera_jun.transform.rotation = Quaternion.LookRotation(target_pos * size);
        }
        /*else
        {
            Debug.Log("지금은 제로임");
            target_pos = Vector3.zero;
            //size = 0;
        }*/
    }
    public void Smoke_Button()
    {
        if (!button_start)
        {
            button_start = true;
            guidance_text.SetActive(false);
            for (int i = 0; i < interaction_button.Length; i++)
            {
                interaction_button[i].interactable = false;
            }
            target = elements[1];
            StartCoroutine(Smoke_Coroutine());
        }
    }
    public void Air_Button()
    {
        if (!button_start)
        {
            button_start = true;
            guidance_text.SetActive(false);
            for (int i = 0; i < interaction_button.Length; i++)
            {
                interaction_button[i].interactable = false;
            }
            target = elements[0];
            StartCoroutine(Air_Coroutine());
        }
    }
    public void Fire_Button()
    {
        if (!button_start)
        {
            button_start = true;
            guidance_text.SetActive(false);
            for (int i = 0; i < interaction_button.Length; i++)
            {
                interaction_button[i].interactable = false;
            }
            target = elements[2];
            StartCoroutine(Fire_Coroutine());
        }
    }
    IEnumerator Smoke_Coroutine()
    {
        Debug.Log("줌인 시작");
        while (camera_jun.in_or_out != zoom_in)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out - Time.deltaTime * zoom_speed, zoom_in, zoom_base);
            yield return null;
        }
        yield return new WaitForSeconds(dealay_time);
        while (camera_jun.in_or_out != zoom_base)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out + Time.deltaTime * zoom_speed, zoom_in, zoom_base);
            yield return null;
        }
        button_start = false;
        interaction_button[0].interactable = true;
    }
    IEnumerator Air_Coroutine()
    {
        while (camera_jun.in_or_out != zoom_out)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out + Time.deltaTime * zoom_speed, zoom_base, zoom_out);
            yield return null;
        }
        yield return new WaitForSeconds(dealay_time);
        while (camera_jun.in_or_out != zoom_base)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out - Time.deltaTime * zoom_speed, zoom_base, zoom_out);
            yield return null;
        }
        button_start = false;
        interaction_button[2].interactable = true;

    }
    IEnumerator Fire_Coroutine()
    {
        while (camera_jun.in_or_out != zoom_in)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out - Time.deltaTime * zoom_speed, zoom_in, zoom_base);
            yield return null;
        }
        yield return new WaitForSeconds(dealay_time);
        while (camera_jun.in_or_out != zoom_base)
        {
            camera_jun.in_or_out = Mathf.Clamp(camera_jun.in_or_out + Time.deltaTime * zoom_speed, zoom_in, zoom_base);
            yield return null;
        }
        button_start = false;
    }
    /* 나중에 참고할 VR 머리회전 멈추는 로직
    using UnityEngine;
    using Valve.VR;

    public class HeadRotationController : MonoBehaviour
    {
        private SteamVR_Action_Pose poseAction;

        private void Start()
        {
            poseAction = SteamVR_Actions.default_Pose;
        }

        private void Update()
        {
            // 머리의 회전을 가져오지 않도록 설정
            poseAction.pose.SetAxis(Vector3.zero);

            // 이제 poseAction.rotation을 사용하지 않고, 머리의 회전을 가져오지 않도록 설정됩니다.
        }
    }*/
}
