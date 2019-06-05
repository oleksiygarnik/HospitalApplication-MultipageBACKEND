using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApplicationFirst.Models.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Specialities { get; private set; }

        public int? SelectedSpecialty { get; private set; }

        public string SelectedName { get; private set; }

        public FilterViewModel(List<Specialty> specialities, int? specialty, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            specialities.Insert(0, new Specialty { Name = "Все", Id = 0 });
            Specialities = new SelectList(specialities, "Id", "Name", specialty);
            SelectedSpecialty = specialty;
            SelectedName = name;
        }
    }
}