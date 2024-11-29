using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraConfinerManager : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineConfiner2D confiner;
    private PolygonCollider2D boundsCollider;

    void Start()
    {
        // Buscar la cámara virtual que se preservó
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        
        if (virtualCamera != null)
        {
            // Obtener o agregar el confiner
            confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
            if (confiner == null)
            {
                confiner = virtualCamera.gameObject.AddComponent<CinemachineConfiner2D>();
            }

            // Buscar el objeto CameraConfiner y obtener su PolygonCollider2D
            GameObject confinerObject = GameObject.Find("CameraConfiner");
            if (confinerObject != null)
            {
                boundsCollider = confinerObject.GetComponent<PolygonCollider2D>();
                if (boundsCollider != null)
                {
                    confiner.m_BoundingShape2D = boundsCollider;
                    confiner.InvalidateCache();
                }
            }

            // Buscar y asignar el jugador como objetivo de la cámara
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                virtualCamera.Follow = player.transform;
            }
        }
    }
}
