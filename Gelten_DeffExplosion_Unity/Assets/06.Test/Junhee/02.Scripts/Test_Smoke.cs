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
    [Header("���� Ȥ�� �ܾƿ� ���ð�")]
    public float dealay_time;
    [Header("Ȯ��")]
    public float zoom_in;
    [Header("���")]
    public float zoom_out;
    int zoom_base = 10;
    [Header("��� Ȯ�� �ӵ�")]
    public float zoom_speed;
    public GameObject[] elements = new GameObject[3];
    public GameObject target;
    Vector3 target_pos;
    float size = 0;
    [Header("��ǥ���� �Ĵٺ��� �ӵ��� ���� ���� ������ ��")]
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
        //�ݵ����̰� �� ���� �Ŀ� �ؽ�Ʈ ���ӿ�����Ʈ Ȱ��ȭ ��Ű��
        //ù��°�� ���Ḧ ���������� -> ��Ҹ� ���������� -> ��ȭ���� ����������
        //�Ʒ��κ� ���߿� �ٲٱ�
        if (time > 5)
        {
            //JUNHEE_PLMING : ���� ���߿� �ݵ����� ���� �Ŀ� �ؽ�Ʈ �����ϴ� �������� �ٲٱ�
            guidance_text.SetActive(true);
        }
        else
        {
            time += Time.deltaTime;
        }
        if (button_start)
        {
            //size = Mathf.Clamp(size + Time.deltaTime * focusing_speed, 0, 1);
            //���� �������ϰ� ȸ������ �ָ鼭 Ÿ���� �ٶ󺸴� ���� �������
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
            Debug.Log("������ ������");
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
        Debug.Log("���� ����");
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
    /* ���߿� ������ VR �Ӹ�ȸ�� ���ߴ� ����
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
            // �Ӹ��� ȸ���� �������� �ʵ��� ����
            poseAction.pose.SetAxis(Vector3.zero);

            // ���� poseAction.rotation�� ������� �ʰ�, �Ӹ��� ȸ���� �������� �ʵ��� �����˴ϴ�.
        }
    }*/
}
