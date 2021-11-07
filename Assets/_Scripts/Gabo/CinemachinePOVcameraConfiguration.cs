using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVcameraConfiguration : MonoBehaviour
{
    PlayerMovementIsaac player;
    public CinemachineVirtualCamera pov;
    public float horizontalPosition = 90;
    public bool right; 
    void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }


    public void Update()
    {
        if (!player.changeCamera )
        {
            pov.AddCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = horizontalPosition;
            if (right)
            {
                pov.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxValue = 180;
                pov.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MinValue = 0;
            }
            else
            {
                pov.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxValue = 0;
                pov.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MinValue = -180;
            }
            pov.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_Wrap = false;
        }
    }
}
