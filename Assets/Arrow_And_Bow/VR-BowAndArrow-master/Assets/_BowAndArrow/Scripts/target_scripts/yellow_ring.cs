using System.Collections;
using UnityEngine;

public class yellow_ring : scoring, IDamageable
{
	//teresa
	MovingManager movingManager;
	public float min = -5f;
	public float max = 5f;
	public float original_min;

	void Start()
	{
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		movingManager = controller.GetComponent<MovingManager>();
		original_min = transform.position.x;
		min = transform.position.x - 5;
		max = transform.position.x + 5;
	}

	void Update()
	{
		transform.position = new Vector3(Mathf.PingPong(Time.time * movingManager.speed, max - min) + min, transform.position.y, transform.position.z);
	}

	void onHit()
    {
		//when the arrow hits yellow
		score = score + 10; // score var from scoring class
		updateScore();
	}

	//jinhong
	public void Damage(int amount)
	{
		TurnRed();
		onHit();
	}

	private void TurnRed()
	{
		MeshRenderer _MeshRenderer = GetComponent<MeshRenderer>();
		MeshRenderer temp = _MeshRenderer; //to hold original material;
		_MeshRenderer.material.color = Color.yellow;
		_MeshRenderer.material = temp.material; //change back to original material
	}

}
