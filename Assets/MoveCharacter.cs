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
	public Texture2D crosshair;

	public enum Movement {Up, Down, Left, Right};




	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}

	void OnGUI()
	{
		float xMin = (Screen.width - Input.mousePosition.x) - (crosshair.width / 4);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshair.height / 4);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width / 2 , crosshair.height / 2), crosshair);
	}
	

	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;
		var hit = new RaycastHit();
		Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 5);

		Movement movesUpDown;
		Movement movesLeftRight;

		if (Input.GetKey (moveUp)) {
			movesUpDown = Movement.Up;
		} else if (Input.GetKey (moveDown)) {
			movesUpDown = Movement.Down;
		}
		if (Input.GetKey (moveLeft)) {
			movesLeftRight = Movement.Left;
		} else if (Input.GetKey (moveRight)) {
			movesLeftRight = Movement.Right;
		}

		if (Input.GetKey (jump)) {
//			rigidbody.AddForce(transform.up, ForceMode.Impulse);
			transform.Translate(0f, speed * Time.deltaTime, 0f);
				}

		if (Input.GetMouseButtonDown(0)) {



			var dist = 100.0f;
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(mouseRay, out hit)){
				dist = hit.distance;
			}

			var point = mouseRay.GetPoint(dist);

//			

			var ballInstance =  Instantiate(ball, transform.position + transform.forward * 1.5f, transform.rotation) as Rigidbody;
			ballInstance.transform.LookAt(point);
			ballInstance.AddForce(ballInstance.transform.forward * 4000F);
			

		}
	}
}