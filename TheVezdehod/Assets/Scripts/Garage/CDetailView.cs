using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CDetailView : MonoBehaviour
	{
		public CDetail detail;
		public IOnDetailClickListener onClickListener;

		void Start()
		{
			GetComponent<Image>().sprite = detail.sprite;
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		private void OnClick()
		{
			onClickListener.OnClick(detail);
		}
	}

	public interface IOnDetailClickListener
	{
		void OnClick(CDetail detail);
	}
}
