using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GarageScene
{
	public class CDetailsGridView : MonoBehaviour
	{
		public IOnTileClick onTileClick { get; set; }

		[SerializeField]
		private Image m_imageProto;
		[SerializeField]
		private RectTransform m_detailParent;

		private int m_width;
		private int m_height;
		private float m_detailSize;
		private CTile[,] m_tiles;

		public void InitSize(uint width, uint height)
		{
			m_detailSize = GetComponent<GridLayoutGroup>().cellSize.x;
			Debug.Log(m_detailSize);
			m_width = (int)width;
			m_height = (int)height;

			m_tiles = new CTile[m_width, m_height];

			int x = 0;
			int y = 0;

			foreach (CTile tile in GetComponentsInChildren<CTile>())
			{
				tile.Position = new Vector2Int(x, y);
				tile.Button.onClick.AddListener(() =>
				{
					OnTileClick(tile);
				});

				m_tiles[x, y] = tile;

				x++;

				if (x == width)
				{
					x = 0;
					++y;
				}
			}

			CloseAll();
		}

		public void OpenAt(int x, int y)
		{
			m_tiles[x, y].Button.interactable = true;
		}

		public void CloseAll()
		{
			foreach (CTile tile in m_tiles)
			{
				tile.Button.interactable = false;
			}
		}

		public void DrawAt(CDetail detail, int x, int y)
		{
			var tile = m_tiles[x, y].transform;

			var detailImage = Instantiate(m_imageProto, tile.position, Quaternion.identity, m_detailParent);
			detailImage.GetComponent<RectTransform>().sizeDelta =
				new Vector2(m_detailSize * detail.width, m_detailSize * detail.height);
			detailImage.sprite = detail.sprite;
		}

		private void OnTileClick(CTile tile)
		{
			onTileClick.OnClick(tile.Position.x, tile.Position.y);
		}
	}

	public interface IOnTileClick
	{
		void OnClick(int x, int y);
	}
}
