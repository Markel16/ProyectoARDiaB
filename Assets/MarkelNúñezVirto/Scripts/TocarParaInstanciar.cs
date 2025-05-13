using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TocarParaInstanciar : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 toquePos = Input.GetTouch(0).position;

            if (raycastManager.Raycast(toquePos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose poseImpacto = hits[0].pose;

                
                FindObjectOfType<ARManager>().InstanciarPrefab(poseImpacto.position);
            }
        }
    }
}
