using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelTouchController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public delegate void PointerDownHandler (PointerEventData data);

	public event PointerDownHandler PointerDown;

	public delegate void PointerUpHandler (PointerEventData data);

	public event PointerUpHandler PointerUp;

	public void OnPointerUp (PointerEventData eventData) {
		if (PointerUp != null)
			PointerUp (eventData);
	}

	public void OnPointerDown (PointerEventData eventData) {
		if (PointerDown != null)
			PointerDown (eventData);
	}
}
