using GarageScene;
using Shared;
using System.Collections.Generic;
using UnityEngine;

namespace RoadScene
{
	public class CVezdehod : MonoBehaviour
	{
		[SerializeField]
		private float m_detailOffset = 1;
		[SerializeField]
		private GameObject m_detailProto;

		private float m_backOffset;
		private float m_downOffset;

		private int m_wheelsCount = 2;
		[SerializeField]
		private PhysicsMaterial2D m_wheelMaterial;

		public CVezdehod()
		{
			m_backOffset = m_detailOffset * 9 / 2;
			m_downOffset = m_detailOffset * 5 / 2;
		}

		private void Awake()
		{
			var car = CDataManager.DeserializeCar();

			for (int i = 0; i < car.details.Count; ++i)
			{
				var detail = car.details[i];
				var adress = car.addreses[i];
				InstantiateDetail(adress.x, adress.y, new CDetail(detail));
			}
		}

		private void InstantiateDetail(int x, int y, CDetail detail)
		{
			var position = new Vector3(
				(m_detailOffset * y - m_backOffset),
				(m_detailOffset * (5 - x) - m_downOffset));

			var detailObject = Instantiate(m_detailProto, position, Quaternion.identity, transform);
			var detailSprite = detailObject.GetComponent<SpriteRenderer>();

			detailSprite.sprite = detail.sprite;
			detailSprite.transform.localScale = new Vector3(
				1 / detailSprite.size.x,
				1 / detailSprite.size.y);

			detailObject.AddComponent(typeof(PolygonCollider2D));

			if (detail.type == DetailType.Wheel && m_wheelsCount >= 0)
			{
				SetupWheel(detailObject, detail, position);
				return;
			}

			var joint = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
			joint.connectedBody = detailObject.GetComponent<Rigidbody2D>();
			joint.anchor = new Vector2(position.x, position.y);
		}

		private void SetupWheel(GameObject wheelObject, CDetail wheel, Vector3 position)
		{
			--m_wheelsCount;

			var joint = gameObject.AddComponent(typeof(WheelJoint2D)) as WheelJoint2D;
			joint.connectedBody = wheelObject.GetComponent<Rigidbody2D>();
			joint.anchor = new Vector2(position.x, position.y);

			if (m_wheelsCount == 1)
			{
				GetComponent<CarController>().frontwheel = joint;
			}
			else if (m_wheelsCount == 0)
			{
				GetComponent<CarController>().backwheel = joint;
			}
		}
	}
}
