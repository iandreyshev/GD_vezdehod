using RoadScene;
using Shared;
using UnityEngine;

public enum Level
{
	_1,
	_2
}

public class CGame : MonoBehaviour
{
	[SerializeField]
	private GameObject m_menu;
	[SerializeField]
	private GameObject m_garage;
	[SerializeField]
	private GameObject m_view;
	[SerializeField]
	private GameObject m_road;
	[SerializeField]
	private GameObject m_finish;

	[SerializeField]
	private GameObject m_carController;
	[SerializeField]
	private CVezdehod m_vezdehod;

	[SerializeField]
	private GameObject m_roadCamera;
	[SerializeField]
	private GameObject m_viewCamera;

	private Level m_level = Level._1;

	public void Start()
	{
		Menu();
	}

	public void Menu()
	{
		PrepareState();

		m_menu.SetActive(true);
	}

	public void Garage()
	{
		Garage(m_level);
	}

	public void Garage(Level level)
	{
		PrepareState();

		m_level = level;
		m_garage.SetActive(true);
	}

	public void View()
	{
		PrepareState();

		m_view.SetActive(true);
		m_viewCamera.SetActive(true);
	}

	public void Road(CCar car)
	{
		PrepareState();

		m_carController.SetActive(true);
		m_vezdehod.Build(car);
		m_road.SetActive(true);
		m_roadCamera.SetActive(true);
	}

	public void FinishGame()
	{
		PrepareState();

		m_finish.SetActive(true);
	}

	private void PrepareState()
	{
		m_roadCamera.SetActive(false);
		m_viewCamera.SetActive(false);

		m_finish.SetActive(false);
		m_road.SetActive(false);
		m_view.SetActive(false);
		m_view.SetActive(false);
		m_garage.SetActive(false);
		m_menu.SetActive(false);
		m_carController.SetActive(false);
	}
}
