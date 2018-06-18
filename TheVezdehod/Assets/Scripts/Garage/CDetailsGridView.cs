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
		private Vector2 m_detailSize;
		private CTile[,] m_tiles;

		public void InitSize(int width, int height)
		{
			m_detailSize = GetComponent<GridLayoutGroup>().cellSize;
			m_width = width;
			m_height = height;

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

            detailImage.GetComponent<RectTransform>().sizeDelta = m_detailSize;
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
