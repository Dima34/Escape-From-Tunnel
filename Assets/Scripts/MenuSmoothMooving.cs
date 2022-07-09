using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class MenuSmoothMooving : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    CinemachineTrackedDolly trackedDolly;

    void Start()
    {
        trackedDolly = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();    
        trackedDolly.m_PathPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        trackedDolly.m_PathPosition += speed / 10 * Time.deltaTime;
    }
}
