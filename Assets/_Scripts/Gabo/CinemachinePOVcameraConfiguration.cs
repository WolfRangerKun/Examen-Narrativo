using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVcameraConfiguration : MonoBehaviour
{
    public PlayerMovementIsaac player;
    public CinemachineVirtualCamera pov;
    public float horizontalPosition = 90;
    void Start()
    {
        player = FindObjectOfType<PlayerMovementIsaac>();
    }


    public void Update()
    {
        if (!player.changeCamera)
        {
            pov.AddCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = horizontalPosition;
        }
    }
}
