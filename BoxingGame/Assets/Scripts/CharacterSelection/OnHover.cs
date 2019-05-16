using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine;
using UnityEngine.UI;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	Ray ray;
	RaycastHit hit;
	Vector3 point;

    public GameObject image;
    public bool isHovering = false;


    public void OnPointerEnter(PointerEventData eventData)
    {	
        isHovering = true;
    }

	public void OnPointerExit(PointerEventData eventData)
	{
        isHovering = false;
    }

    void Update()
    {
      point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isHovering == true)
        {
           image.SetActive(true);
        }

        else if (isHovering == false)
        {
           image.SetActive(false);
        }


    }


    void OnDrawGizmos()
	{
		point.z = 0;
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(point, 0.5f);
		Gizmos.DrawSphere(Vector3.zero, 0.5f);
	}
}
