using GarageScene;
using System.Collections.Generic;

namespace Shared
{
	[System.Serializable]
	public class CVect
	{
		public CVect(int x = 0, int y = 0)
		{
			this.x = x;
			this.y = y;
		}

		public int x;
		public int y;
	}

	[System.Serializable]
	public class CCar
	{
		public List<DetailData> details = new List<DetailData>();
		public List<CVect> addreses = new List<CVect>();

		public void Insert(DetailData detail, int x, int y)
		{
			details.Add(detail);
			addreses.Add(new CVect(x, y));
		}
	}
}
