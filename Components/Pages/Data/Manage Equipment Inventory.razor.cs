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

		protected override void OnInitialized()
		{
			EquipmentDbAccessor.CreateEquipmentTable();

			equipments = EquipmentDbAccessor.GetEquipments();
		}

		public void Add(Equipment equipment)
		{
			int id = EquipmentDbAccessor.AddEquipment(equipment);

			// System.Diagnostics.Debug.WriteLine("ID is " + id);
			Equipment newEquipment = new Equipment(id, equipment.CategoryId, equipment.EquipmentName, equipment.EquipmentDescription, equipment.DailyRate);
			equipments.Add(newEquipment);
		}

		public void Delete(Equipment equipment)
		{
			equipments.Remove(equipment);
			EquipmentDbAccessor.DeleteEquipment(equipment.EquipmentId);
		}
	}

}