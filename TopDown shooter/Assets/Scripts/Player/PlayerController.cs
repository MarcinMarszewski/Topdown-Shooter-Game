using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb2D;
	[SerializeField]
	Shield shield;
	[SerializeField]
	Gun pistol;

	[SerializeField]
	float speed;
	[SerializeField]
	float turnSpeed;


	Camera main;

	// Start is called before the first frame update
	void Start()
	{
		main = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		HandleMovement();
		HandleRotation();
		HandleShielding();
		HandleShooting();
	}

	void HandleMovement()
	{
		rb2D.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;
	}

	void HandleRotation()
	{
		Vector3 targetDirection = main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		targetDirection.z = 0;
		transform.rotation =
			Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, targetDirection), Time.deltaTime * turnSpeed);
	}

	void HandleShielding()
	{
		shield.UpdateShield(Input.GetAxisRaw("Shield")==1);	//nie jestem pewny czy przyrównanie z float to dobry pomys³
	}

	void HandleShooting()
	{
		if (Input.GetAxisRaw("Fire") == 1) pistol.ShootTrigger(); //to samo co w HandleShielding
		if (Input.GetAxisRaw("Fire") == -1) pistol.ReloadTrigger();
	}
}
