using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GarageScene
{
	public enum SkeletonType
	{
		None,
		Lenovo,
		Goliath
	}

	public enum CanBeInsertedInfo
	{
		YesNoProblem,
		ToMuchWheels,
		ToMuchEngines,
		InvalidPosition
	}

	public class GridItem
	{
		public GridItem(int x, int y, DetailData detail)
		{
			this.x = x;
			this.y = y;
			this.detail = detail;
		}

		public int x;
		public int y;
		public DetailData detail;
	}

	public class CGridModel
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		private List<GridItem> m_details = new List<GridItem>();
		private SkeletonType m_skeleton = SkeletonType.None;
		private int m_wheelsCount = 0;

		private IDictionary<DetailType, int> m_counts = new Dictionary<DetailType, int>()
		{
			{ DetailType.Artifact, 0 },
			{ DetailType.Block, 0 },
			{ DetailType.Engine, 0 },
			{ DetailType.FuelBank, 0 },
			{ DetailType.Wheel, 0 }
		};

		public CGridModel()
		{
			Width = 9;
			Height = 5;
		}

		public void SetSkeleton(SkeletonType skeleton, DetailData prototype)
		{
			Clear();
			var points = GetSkeletonPoints(skeleton);
			foreach (var point in points)
			{
				InsertDetail(point.x, point.y, prototype);
			}
			m_skeleton = skeleton;
		}

		public SkeletonType GetSkeletonType()
		{
			return m_skeleton;
		}

		public void InsertDetail(int x, int y, DetailData detail)
		{
			m_details.Add(new GridItem(x, y, detail));
			UpdateDetailsCount();
		}

		public List<GridItem> GetInstalledBlocks()
		{
			return m_details;
		}

		public List<Vector2Int> GetAvailablePositionsForInsertion(DetailData detail)
		{
			List<Vector2Int> positions = new List<Vector2Int>();
			for (int i = 0; i < Height; ++i)
			{
				for (int j = 0; j < Width; ++j)
				{
					if (CanBeInserted(j, i, detail) == CanBeInsertedInfo.YesNoProblem)
					{
						positions.Add(new Vector2Int(j, i));
					}
				}
			}
			return positions;
		}

		public CanBeInsertedInfo CanBeInserted(int x, int y, DetailData detail)
		{
			// Если колес уже два нельзя вставить больше
			if (detail.type == DetailType.Wheel && m_counts[DetailType.Wheel] >= 2)
			{
				return CanBeInsertedInfo.ToMuchWheels;
			}

			// Двигатель только один
			if (detail.type == DetailType.Engine && m_counts[DetailType.Engine] >= 1)
			{
				return CanBeInsertedInfo.ToMuchEngines;
			}

			foreach (var inserted in m_details)
			{
				if (x == inserted.x + 1 && y == inserted.y && x > 0 && x < Width ||
					x == inserted.x - 1 && y == inserted.y && x > 0 && x < Width ||
					y == inserted.y - 1 && x == inserted.x && y > 0 && y < Height ||
					y == inserted.y + 1 && x == inserted.x && y > 0 && y < Height)
				{
					return inserted.detail.type == DetailType.Block ?
						CanBeInsertedInfo.YesNoProblem : CanBeInsertedInfo.InvalidPosition;
				}
			}
			return CanBeInsertedInfo.InvalidPosition;
		}

		public void DeleteDetail(int x, int y)
		{
			m_details.RemoveAll((GridItem item) =>
			{
				return item.x == x && item.y == y;
			});
			UpdateDetailsCount();
		}

		public void Clear()
		{
			m_details.Clear();
			m_skeleton = SkeletonType.None;
			UpdateDetailsCount();
		}

		void UpdateDetailsCount()
		{
			m_counts = new Dictionary<DetailType, int>()
			{
				{ DetailType.Artifact, 0 },
				{ DetailType.Block, 0 },
				{ DetailType.Engine, 0 },
				{ DetailType.FuelBank, 0 },
				{ DetailType.Wheel, 0 }
			};
			foreach (var item in m_details)
			{
				++m_counts[item.detail.type];
			}
		}

		public bool CanBeDeleted(int x, int y)
		{
			var points = GetSkeletonPoints(m_skeleton);

			foreach (var point in points)
			{
				if (point.x == x && point.y == y)
				{
					return false;
				}
			}

			foreach (var detail in m_details)
			{
				if (detail.x == x && detail.y == y)
				{
					return true;
				}
			}

			return false;
		}

		public DetailData GetDetail(int x, int y)
		{
			foreach (var item in m_details)
			{
				if (item.x == x && item.y == y)
				{
					return item.detail;
				}
			}
			return null;
		}

		public List<Vector2Int> GetSkeletonPoints(SkeletonType skeleton)
		{
			switch (skeleton)
			{
				case SkeletonType.Lenovo:
					return new List<Vector2Int>()
				{
					new Vector2Int(1, 3),
					new Vector2Int(1, 2),
					new Vector2Int(1, 1),
					new Vector2Int(2, 1),
					new Vector2Int(3, 1),
					new Vector2Int(4, 1),
					new Vector2Int(5, 1),
					new Vector2Int(6, 1),
					new Vector2Int(7, 2),
					new Vector2Int(7, 3)
				};
				case SkeletonType.Goliath:
					return new List<Vector2Int>()
				{
					new Vector2Int(0, 2),
					new Vector2Int(1, 2),
					new Vector2Int(2, 2),
					new Vector2Int(3, 2),
					new Vector2Int(4, 2),
					new Vector2Int(5, 2),
					new Vector2Int(6, 2),
					new Vector2Int(7, 2),
					new Vector2Int(8, 2),
					new Vector2Int(0, 3),
					new Vector2Int(1, 3),
					new Vector2Int(2, 3),
					new Vector2Int(3, 3),
					new Vector2Int(4, 3),
					new Vector2Int(5, 3),
					new Vector2Int(6, 3),
					new Vector2Int(7, 3),
					new Vector2Int(8, 3)
				};
				case SkeletonType.None:
					return new List<Vector2Int>();
			}
			throw new Exception("FATAL ERROR");
		}
	}
}