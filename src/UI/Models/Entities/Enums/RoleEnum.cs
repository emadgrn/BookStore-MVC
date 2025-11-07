using System.ComponentModel.DataAnnotations;

namespace UI.Models.Entities.Enums;

public enum RoleEnum
{
    [Display(Name = "مدیر")]
    Admin = 1,

    [Display(Name = "مشتری")]
    Customer = 2
}