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





	// Use this for initialization
	void Start () {

	}
	

	// Update is called once per frame
	void Update () {


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

		if (Input.GetMouseButtonDown(0)) {


			var hit = new RaycastHit();
			var dist = 100.0f;
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(mouseRay, out hit)){
				dist = hit.distance;
			}

			var point = mouseRay.GetPoint(dist);

//			mousePos = Input.mousePosition;
//			//ballPos = Camera.current.ScreenToWorldPoint(mousePos);
//			cameraPos = Camera.main.ScreenToWorldPoint(mousePos);// - new Vector3(0,0, - 2);
//			cameraPos.z = 0;
//			var mouseDir = cameraPos - transform.position;
//			mouseDir = cameraPos.normalized;

			Rigidbody ballInstance =  Instantiate(ball, transform.position + transform.forward * 1.5f, transform.rotation) as Rigidbody;
			ballInstance.transform.LookAt(point);
//			ballInstance.AddForce(cameraPos + transform.forward * 10.0f);
			ballInstance.AddForce(ballInstance.transform.forward * 2000F);
			

		}
	}
}