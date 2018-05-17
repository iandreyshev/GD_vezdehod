using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GarageScene
{
	public enum Skeleton
	{
		Lenovo,
		Goliath
	}

	public class GridItem
	{
		public GridItem(uint row, uint col, CDetail detail)
		{
			this.row = row;
			this.col = col;
			this.detail = detail;
		}

		public uint row;
		public uint col;
		public CDetail detail;
	}

	public class BlockItem
	{
		public BlockItem(uint row, uint col, DetailType type)
		{
			this.row = row;
			this.col = col;
			this.type = type;
		}

		public uint row;
		public uint col;
		public DetailType type;
	}

	public class CGridModel : MonoBehaviour
	{
		private uint m_cols = 9;
		private uint m_rows = 5;

		[SerializeField]
		private Skeleton m_skeleton = Skeleton.Lenovo; // lenovo by default

		private List<GridItem> m_insertedItems = new List<GridItem>();

		void Start()
		{
			SetSkeleton(m_skeleton);
		}

		public bool PossibleToInsertAt(CDetail detail, uint row, uint col)
		{
			if (row >= m_rows || col >= m_cols)
			{
				return false;
			}

			foreach (GridItem item in m_insertedItems)
			{
				if (row >= item.row && row <= item.row + item.detail.height &&
					col >= item.col && col <= item.col + item.detail.width)
				{
					return false;
				}
			}

			return true;//IsTypeAvailableAtPosition(detail.type, row, col);
		}

		public List<Vector2Int> GetAvailablePositionsForDetail(CDetail detail)
		{
			List<Vector2Int> positions = new List<Vector2Int>();
			for (uint row = 0; row < m_rows; ++row)
			{
				for (uint col = 0; col < m_cols; ++col)
				{
					if (PossibleToInsertAt(detail, row, col))
					{
						positions.Add(new Vector2Int((int)col, (int)row));
					}
				}
			}
			return positions;
		}

		public bool CanBeDeletedAt(uint row, uint col)
		{
			// Нельзя удалить блок из каркаса
			if (m_skeleton == Skeleton.Lenovo)
			{
				if (row == 2 && col == 1)
				{
					return false;
				}
			}
			if (m_skeleton == Skeleton.Goliath)
			{
				if (row == 1 && col == 0 || row == 2 && col == 0)
				{
					return false;
				}
			}

			foreach (var item in m_insertedItems)
			{
				if (item.row == row && item.col == col)
				{
					return true;
				}
			}

			return false;
		}

		public void DeleteDetail(uint row, uint col)
		{
			if (!CanBeDeletedAt(row, col))
			{
				throw new Exception("detail can't be deleted");
			}
			m_insertedItems.RemoveAll((GridItem item) =>
			{
				return item.col == col && item.row == row;
			});
		}

		public List<CDetail> GetInstalledDetails()
		{
			var result = new List<CDetail>();

			foreach (GridItem item in m_insertedItems)
			{
				result.Add(item.detail);
			}

			return result;
		}

		public List<GridItem> GetInstalledItems()
		{
			return m_insertedItems;
		}

		public void SetDetailAt(CDetail detail, uint row, uint col)
		{
			// Лучше проверять assert'ом в Debug моде, ибо подразумевается использование if'а перед вызовом метода
			// if (!PossibleToInsertAt(detail, row, col))
			// {
			// throw new Exception("it's not possible to set that detail");
			// }
			m_insertedItems.Add(new GridItem(row, col, detail));
		}

		public CDetail GetDetailAt(uint row, uint col)
		{
			foreach (var item in m_insertedItems)
			{
				if (item.col == col && item.row == row)
				{
					return item.detail;
				}
			}
			return null;
		}

		private CDetail CreateSkeletonDetailBlock(int width, int height, int mass)
		{
			CDetail detail = new CDetail
			{
				width = width,
				height = height,
				mass = mass
			};
			return detail;
		}

		public void SetSkeleton(Skeleton skeleton)
		{
			Clear();
			m_skeleton = skeleton;
			if (m_skeleton == Skeleton.Lenovo)
			{
				SetDetailAt(CreateSkeletonDetailBlock(4, 1, 100), 2, 1);
			}
			else if (m_skeleton == Skeleton.Goliath)
			{
				SetDetailAt(CreateSkeletonDetailBlock(6, 1, 250), 1, 0);
				SetDetailAt(CreateSkeletonDetailBlock(6, 1, 250), 2, 0);
			}
		}

		public Skeleton GetSkeleton()
		{
			return m_skeleton;
		}

		public void Clear()
		{
			m_insertedItems.Clear();
		}

		public uint GetRowsCount()
		{
			return m_rows;
		}

		public uint GetColumnsCount()
		{
			return m_cols;
		}
	}
}