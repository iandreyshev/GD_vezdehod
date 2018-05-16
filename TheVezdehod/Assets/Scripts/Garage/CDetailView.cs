using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CDetailView : MonoBehaviour
	{
		[SerializeField]
		private CDetail detail;

		[SerializeField]
		private Image image;

		void Start()
		{
			image.sprite = detail.m_icon;
		}
	}
}
