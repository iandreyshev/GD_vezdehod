using UnityEngine;

public class CarController : MonoBehaviour
{
	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;

	[SerializeField]
	private RectTransform m_forwardPedal;
	[SerializeField]
	private RectTransform m_backPedal;

	JointMotor2D motorFront;
	JointMotor2D motorBack;

	public float speedF;
	public float speedB;

	public float torqueF;
	public float torqueB;

	public bool TractionFront = true;
	public bool TractionBack = true;

	private bool m_isForward = false;
	private bool m_isBack = false;

	public float carRotationSpeed;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxisRaw("Vertical") > 0 || m_isForward)
		{
			if (TractionFront)
			{
				motorFront.motorSpeed = speedF * -1;
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack)
			{
				motorBack.motorSpeed = speedF * -1;
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;
			}
		}
		else if (Input.GetAxisRaw("Vertical") < 0 || m_isBack)
		{
			if (TractionFront)
			{
				motorFront.motorSpeed = speedB * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack)
			{
				motorBack.motorSpeed = speedB * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;
			}
		}
		else
		{
			backwheel.useMotor = false;
			frontwheel.useMotor = false;
		}

		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);
		}
	}

	public void SetForaward(bool isForward)
	{
		m_isForward = isForward;
	}

	public void SetBack(bool isBack)
	{
		m_isBack = isBack;
	}
}
