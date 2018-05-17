using GarageScene;
using System.Collections.Generic;

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
	public List<CDetail> details = new List<CDetail>();
	public List<CVect> addreses = new List<CVect>();

	public void Insert(CDetail detail, int x, int y)
	{
		details.Add(detail);
		addreses.Add(new CVect(x, y));
	}
}
