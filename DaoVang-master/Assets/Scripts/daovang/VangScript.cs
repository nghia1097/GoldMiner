using UnityEngine;
using System.Collections;

public class VangScript : MonoBehaviour {
	public int weight;
	public bool isMoveFollow = false;
	public float maxY;
	public int score;
	public float speed,_speed;
	int x = 1;

	// Use this for initialization
	void Start () {
		isMoveFollow = false;
		_speed = GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// cap nhat x gia tri vat the
		x = GameObject.Find("GamePlay").GetComponent<ClickButton>().x;
	}

	void FixedUpdate() {
		moveFllowTarget(GameObject.Find("luoiCau").transform);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "luoiCau") {
			isMoveFollow = true;
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
			GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().velocity = -GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().velocity;
			if(GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed <= speed)
            {
				GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed = 0;
			}
			else
            {
				GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed -= this.speed;
			}
		}
	}

	void moveFllowTarget(Transform target) {
		if(isMoveFollow) 
		{
				/*Quaternion tg = Quaternion.Euler(target.parent.transform.rotation.x, 
				                                 target.parent.transform.rotation.y, 
				                                 90 + target.parent.transform.rotation.z);*/
				// transform.rotation = Quaternion.Slerp(transform.rotation, tg, 0.5f);
				transform.position = new Vector3(target.position.x, 
				                                 target.position.y - gameObject.GetComponent<Collider2D>().GetComponent<Collider2D>().bounds.size.y / 2, 
				                                 transform.position.z);	
			if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.Nghi) {
				GameObject.Find("GamePlay").GetComponent<GamePlayScript>().score += this.score * x;
				Destroy(gameObject);
				// khoi phuc toc do luoi cau
				if (GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed < _speed)
				{
					GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed = _speed;
				}
				else
                {
					GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed = GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed;

				}
			}
		}
	}
}
