using System.Collections.Generic;
using UnityEngine;

namespace GarageScene
{
	public class CDetailsListView : MonoBehaviour
	{
		[SerializeField]
		private List<CDetail> m_details;
		[SerializeField]
		private CDetailView m_detailViewProto;
		[SerializeField]
		private CDetailsGridView m_gridView;

		private OnDetailClickListener m_onClickListener;
		private CGridModel m_gridModel;
		private CDetail m_selectedDetail;

		private void Start()
		{
			m_onClickListener = new OnDetailClickListener(this);

			var transform = GetComponent<RectTransform>();
			var offset = 0f;

			foreach (CDetail detail in m_details)
			{
				var detailView = Instantiate(m_detailViewProto, transform);
				detailView.onClickListener = m_onClickListener;
				detailView.detail = detail;

				var viewRectTransform = detailView.GetComponent<RectTransform>();
				viewRectTransform.Translate(new Vector3(offset, 0, 0));

				offset += viewRectTransform.rect.height;
			}

			m_gridModel = new CGridModel();
			m_gridView.InitSize(m_gridModel.GetColumnsCount(), m_gridModel.GetRowsCount());
			m_gridView.onTileClick = new OnTileClickListener(this);
		}

		private class OnDetailClickListener : IOnDetailClickListener
		{
			CDetailsListView m_view;

			public OnDetailClickListener(CDetailsListView view)
			{
				m_view = view;
			}

			public void OnClick(CDetail detail)
			{
				m_view.m_selectedDetail = detail;
				var positions = m_view.m_gridModel.GetAvailablePositionsForDetail(detail);
				
				foreach (Vector2Int vect in positions)
				{
					m_view.m_gridView.OpenAt(vect.x, vect.y);
				}
			}
		}

		private class OnTileClickListener : IOnTileClick
		{
			CDetailsListView m_view;

			public OnTileClickListener(CDetailsListView view)
			{
				m_view = view;
			}

			public void OnClick(int x, int y)
			{
				m_view.m_gridView.DrawAt(m_view.m_selectedDetail, x, y);
				m_view.m_gridView.CloseAll();
			}
		}
	}
}
