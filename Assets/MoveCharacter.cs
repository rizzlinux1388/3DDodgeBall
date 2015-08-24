using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	public float speed = 10;
	
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveRight;
	public KeyCode moveLeft;
	public KeyCode mouseClick;
	public KeyCode jump;

	public Rigidbody ball;

	private RaycastHit hit;





	// Use this for initialization
	void Start () {

	}
	

	// Update is called once per frame
	void Update () {
		Vector3 mousePos;
		Vector3 cameraPos;
		var ray = Camera.main.ViewportPointToRay(new Vector3 (0.5F, 0.5F, 0));
		var playerPane = new Plane (Vector3.up, transform.position);
		var hitDist = 0.0f;


		if (Input.GetKey (moveUp)) {
			if (Input.GetKey (moveLeft)){
				rigidbody.AddForce(transform.forward * speed);
				rigidbody.AddForce(transform.right * -speed);
			}
			else if (Input.GetKey (moveRight)){
				rigidbody.AddForce(transform.forward * speed);
				rigidbody.AddForce(transform.right * speed);
			}
			else{
				rigidbody.AddForce(transform.forward * speed);
			}
		}
		else if (Input.GetKey (moveDown)) {
			if (Input.GetKey (moveLeft)){
				rigidbody.AddForce(transform.forward * -speed);
				rigidbody.AddForce(transform.right * -speed);
			}
			else if (Input.GetKey (moveRight)){
				rigidbody.AddForce(transform.forward * -speed);
				rigidbody.AddForce(transform.right * speed);
			}
			else{
				rigidbody.AddForce(transform.forward * -speed);
			}
		}
		else if (Input.GetKey (moveLeft)) {
			rigidbody.AddForce(transform.right * -speed);
			
		}
		else if (Input.GetKey (moveRight)) {
			rigidbody.AddForce(transform.right * speed);
			
		}

		if (Input.GetKey (jump)) {
//			rigidbody.AddForce(transform.up, ForceMode.Impulse);
			transform.Translate(0f, speed * Time.deltaTime, 0f);
				}

		if (Input.GetKey (mouseClick)) {

//			if(playerPane.Raycast(ray, out hitDist)){
//				var direction = ray.GetPoint(hitDist) - transform.position;
//				if (Physics.Raycast(transform.position, direction, out hit, 50.0f)) {
//					if (hit.rigidbody){
//						hit.transform.root.rigidbody.AddForceAtPosition(5.0f * direction, hit.point);
//					}
//				}
//			}

			mousePos = Input.mousePosition;
			//ballPos = Camera.current.ScreenToWorldPoint(mousePos);
			cameraPos = Camera.main.ScreenToWorldPoint(mousePos);// - new Vector3(0,0, - 2);
			cameraPos.z = 0;
			var mouseDir = cameraPos - transform.position;
			mouseDir = cameraPos.normalized;

			Rigidbody ballInstance =  Instantiate(ball, transform.position + transform.forward * 5.0f, transform.rotation) as Rigidbody;
//			ballInstance.AddForce(cameraPos + transform.forward * 10.0f);
			ballInstance.AddForce(mouseDir);
			

		}
	}
}