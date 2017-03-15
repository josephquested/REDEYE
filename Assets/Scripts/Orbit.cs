using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
		Transform center;

		public GameObject centreObj;
		public Vector3 axis = Vector3.up;
		public Vector3 desiredPosition;
		public float radius;
		public float radiusSpeed;
		public float rotationSpeed;

		void Start () {
				center = centreObj.transform;
				transform.position = (transform.position - center.position).normalized * radius + center.position;
		}

		void Update () {
				transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
				desiredPosition = (transform.position - center.position).normalized * radius + center.position;
				transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
		}
}
