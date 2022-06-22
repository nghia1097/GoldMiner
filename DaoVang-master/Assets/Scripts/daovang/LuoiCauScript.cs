using UnityEngine;
using System.Collections;

public class LuoiCauScript : MonoBehaviour {
	// tang toc thu hoi luoi cau khi ko trung vat the
	public float multiSpeed;
	// vat the bi moc
	GameObject obj;
	public bool isTouchObj = false;

	public float speed;
	public float speedMin;
	public float speedBegin;
	public Vector2 velocity;
	public float maxX;
	public float minX;
	public float minY;
	public float maxY;
	public Transform target;
	Vector3 prePosition;

	// Use this for initialization
	void Start () {
		prePosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		checkKeoCauXong();
		checkTouchScene();
		checkMoveOutCameraView();
	}
	void FixedUpdate() {
		if (GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau ||
			   GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau)
			GetComponent<Rigidbody2D>().velocity = velocity * speed;
	}


	bool checkPositionOutBound() {
		return  gameObject.GetComponent<Renderer>().isVisible ;
	}

	void checkTouchScene() {
		bool istouch = Input.GetMouseButtonDown(0);
		if(istouch && GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.Nghi)
		{
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.ThaCau;
			velocity = new Vector2(transform.position.x - target.position.x, 
			                       transform.position.y - target.position.y);
			velocity.Normalize();
			//speed = speedBegin;
		}
	}
	//kiem tra khi luoi cau ra ngoai tam nhin cua camera
	void checkMoveOutCameraView() {
		if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau) {
			if(!checkPositionOutBound()) {
				GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
				// tang toc do thu hoi
				velocity = -velocity * multiSpeed;
				// velocity = -velocity;
			}
		}
	}

	//kiem tra khi luoi ca keo len mat nuoc
	void checkKeoCauXong() {
		if(transform.localPosition.y > maxY && GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau) {
			// Debug.Log("keo cau xong");
			isTouchObj = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.Nghi;
			transform.localPosition = prePosition;
		}
	}

    // nem bom => thu hoi luoi cau

    private void OnTriggerEnter2D(Collider2D collision)
    {
		obj = collision.gameObject;
		isTouchObj = true;
    }

    public void Bomb()
    {
		isTouchObj = false;
		Destroy(obj);
		// tang toc do thu hoi
		velocity = velocity * multiSpeed;
	}
}
