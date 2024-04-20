using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareAnalysis.Models;

namespace SoftwareAnalysis
{
	public partial class Manage_Equipment : ComponentBase
	{
		private EquipmentDbAccessor EquipmentDbAccessor = new EquipmentDbAccessor();

		public List<Equipment> equipments = new List<Equipment>();

		public string errorMessage;

		protected override void OnInitialized()
		{
			try
			{
				EquipmentDbAccessor.CreateEquipmentTable();

				equipments = EquipmentDbAccessor.GetEquipments();
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}

		}

		public void Add(Equipment equipment)
		{
			try
			{
				int id = EquipmentDbAccessor.AddEquipment(equipment);

				// System.Diagnostics.Debug.WriteLine("ID is " + id);
				Equipment newEquipment = new Equipment(id, equipment.CategoryId, equipment.EquipmentName, equipment.EquipmentDescription, equipment.DailyRate);
				equipments.Add(newEquipment);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
			}

		}

		public void Delete(Equipment equipment)
		{
			try
			{
				equipments.Remove(equipment);
				EquipmentDbAccessor.DeleteEquipment(equipment.EquipmentId);
			}
			catch (Exception ex)
			{
				errorMessage = $"Error Occured: {ex.Message}";
				equipments.Add(equipment);
			}
			
		}
	}

}