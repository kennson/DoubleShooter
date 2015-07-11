using UnityEngine;
using UnityEngine .UI;
using UnityEngine .EventSystems;
using System.Collections;

public class BlueTouch : MonoBehaviour, IPointerDownHandler , IDragHandler , IPointerUpHandler {

	public float smoothing;

	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private bool touched;
	private int pointerID;
	private bool canFire;

	void Awake()
	{
		direction = Vector2 .zero;
		touched = false;
	}

	public void OnPointerDown (PointerEventData data)
	{
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			origin = data.position;
			canFire = true;
		}
	}

	public void OnDrag (PointerEventData data) 
	{
		if (data.pointerId == pointerID) {
			Vector2 currentPosition = data .position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw .normalized;
		}
	}

	public void OnPointerUp (PointerEventData data)
	{
		if (data.pointerId == pointerID) {
			direction = Vector3.zero;
			touched = false;
			canFire = false;
		}
	}

	public Vector2 GetDirection()
	{
		smoothDirection = Vector2 .MoveTowards (smoothDirection ,direction ,smoothing);
		return smoothDirection;
	}

	public bool CanFire()
	{
		return canFire;
	}
}
