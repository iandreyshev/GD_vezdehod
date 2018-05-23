using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		[SerializeField]
		private CDetailPropertiesView m_detailProperties;
		[SerializeField]
		private CCarPropertiesView m_carPropertiesView;
		[SerializeField]
		private CDetail m_sceletonProto;

		[SerializeField]
		private CStartButton m_startButton;

		private OnDetailClickListener m_onClickListener;
		private CGridModel m_gridModel = new CGridModel();
		private CDetail m_selectedDetail;
		private List<CDetailView> m_detailsViews = new List<CDetailView>();

		private void Start()
		{
			m_onClickListener = new OnDetailClickListener(this);

			var transform = GetComponent<RectTransform>();
			var offset = 0f;

			foreach (CDetail detail in m_details)
			{
				var view = Instantiate(m_detailViewProto, transform);
				view.onClickListener = m_onClickListener;
				view.detail = detail;

				var viewRectTransform = view.GetComponent<RectTransform>();
				viewRectTransform.Translate(new Vector3(offset, 0, 0));

				offset += viewRectTransform.rect.height;

				m_detailsViews.Add(view);
			}

			m_gridView.InitSize(m_gridModel.Width, m_gridModel.Height);
			m_gridView.onTileClick = new OnTileClickListener(this);

			m_gridModel.SetSkeleton(SkeletonType.Goliath, m_sceletonProto.Data);
			m_gridModel.GetInstalledBlocks().ForEach(e =>
			{
				m_gridView.DrawAt(m_sceletonProto, e.x, e.y);
			});

			m_startButton.GridModel = m_gridModel;
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

				var availablePositions = m_view.m_gridModel
					.GetAvailablePositionsForInsertion(m_view.m_selectedDetail.Data);
				
				foreach (Vector2Int vect in availablePositions)
				{
					m_view.m_gridView.OpenAt(vect.x, vect.y);
				}

				m_view.m_detailProperties.Set(m_view.m_selectedDetail);
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
				m_view.m_detailProperties.Close();

				m_view.m_gridModel.InsertDetail(x, y, m_view.m_selectedDetail.Data);
				m_view.m_carPropertiesView.Set(m_view.m_gridModel.GetInstalledBlocks().ConvertAll(e => new CDetail(e.detail)));

				m_view.m_detailsViews.ForEach((e) =>
				{
					if (e.detail == m_view.m_selectedDetail)
					{
						e.GetComponent<Button>().interactable = false;
					}
				});
			}
		}
	}
}
