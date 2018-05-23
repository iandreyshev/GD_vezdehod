using GarageScene;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoadScene
{
	public class CBarController : MonoBehaviour
	{
		[SerializeField]
		private Text m_cash;
		[SerializeField]
		private Text m_progress;
		[SerializeField]
		private Text m_timer;
		[SerializeField]
		private CPropertyBar m_nitro;

		public void SetCash(int value)
		{
			m_cash.text = string.Format("${0}", value);
		}

		public void SetProgress(float startPosition, float endPosition, float currPosition)
		{
			var length = endPosition - startPosition;
			m_progress.text = string.Format("{0}m / {1}m", (int)currPosition, (int)length);
		}

		public void SetTime(long timeInMillis)
		{
			TimeSpan t = TimeSpan.FromMilliseconds(timeInMillis);
			m_timer.text = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
							t.Hours,
							t.Minutes,
							t.Seconds,
							t.Milliseconds);
		}

		public void SetNitro(float max, float current)
		{
			m_nitro.Max = max;
			m_nitro.Value = current;
		}
	}
}
