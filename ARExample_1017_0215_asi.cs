// 代码生成时间: 2025-10-17 02:15:23
using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARExample : MonoBehaviour
{
# 改进用户体验
    // Reference to the AR Session
    private ARSession arSession;

    // Reference to the AR Session Origin
    private ARSessionOrigin arSessionOrigin;

    // Start is called before the first frame update
    void Start()
    {
# NOTE: 重要实现细节
        // Get the AR Session from the AR Session Origin component
        arSessionOrigin = GetComponent<ARSessionOrigin>();
        arSession = arSessionOrigin.GetComponent<ARSession>();

        // Check if the session is available
        if (arSession == null)
        {
            Debug.LogError("AR Session not found. Make sure your project has AR Foundation installed and configured properly.");
        }
        else
        {
# 增强安全性
            // Configure the AR Session
            arSession.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
# TODO: 优化性能
        // Check for any planes detected by the AR system
# 优化算法效率
        if (arSession != null)
# 扩展功能模块
        {
            foreach (var plane in arSession.GetTrackables<ARPlaneManager, ARPlane>(ARPlaneManager.trackableType.Horizontal))
            {
                if (plane.trackingState == TrackingState.Tracking)
                {
                    // Place a virtual object on the detected plane
                    GameObject virtualObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    virtualObject.transform.position = plane.transform.position;
# 添加错误处理
                    virtualObject.transform.rotation = plane.transform.rotation;

                    // Set the size of the virtual object (optional)
                    virtualObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
# 扩展功能模块
                }
            }
        }
    }
}
