using UnityEngine;

public class Pipe_Control : MonoBehaviour
{
    public Transform background1_pipe;
    public GameObject pipe1_Prefab, pipe2_Prefab, pipe3_Prefab, pipe4_Prefab, pipe5_Prefab;
    Camera mainCamera;
    //�ܵ��ƶ��ٶ�
    readonly float speed = 0.6f;
    //�÷�
    public int score;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        foreach (Transform t in transform)
        {
            //�ƶ��ܵ�
            Vector3 v = t.localPosition;
            v.x -= Time.deltaTime * speed;
            t.localPosition = v;
        }

        //ɾ���ɹ�������Ұ��Ĺܵ�
        if (background1_pipe != null && !IsPipeInView(mainCamera, background1_pipe))
        {
            Destroy(background1_pipe.gameObject);
        }

        //��ͬ�÷ִ�����ͬ�ܵ�
        switch (score / 10)
        {
            case 0:
                CreateNewPipe(pipe1_Prefab, -1.8f, 1.2f);
                break;
            case 1:
                CreateNewPipe(pipe2_Prefab, -1.3f, 1.2f);
                break;
            case 3:
                CreateNewPipe(pipe3_Prefab, -0.8f, 1.2f);
                break;
            case 4:
                CreateNewPipe(pipe4_Prefab, -0.3f, 1.2f);
                break;
            case 5:
                CreateNewPipe(pipe5_Prefab, 0.2f, 1.2f);
                break;
        }
    }

    bool IsPipeInView(Camera cam, Transform pipeTrans)
    {
        // ��ȡ�������������
        Vector3 pipePos = pipeTrans.position;

        // ���������������ת��Ϊ�ӿ�����
        Vector3 pipeViewportPos = cam.WorldToViewportPoint(pipePos);

        // �ж��ӿ������Ƿ���[0,1]��Χ��
        bool isInView = pipeViewportPos.x >= -0.25f;

        return isInView;
    }

    //�����µĹܵ�
    private void CreateNewPipe(GameObject pipe_Prefab, float start, float end)
    {
        if (gameObject.transform.childCount == 0)
        {
            background1_pipe = Instantiate(pipe_Prefab).transform;
            background1_pipe.SetParent(gameObject.transform);
            float pipeHeight = Random.Range(start, end);
            Vector3 newPipePos = new(3, pipeHeight, 0);
            background1_pipe.localPosition = newPipePos;
        }
    }
}
