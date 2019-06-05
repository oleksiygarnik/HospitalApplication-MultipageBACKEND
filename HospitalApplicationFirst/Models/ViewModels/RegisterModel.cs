using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество пользователя")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указана почта пользователя")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}