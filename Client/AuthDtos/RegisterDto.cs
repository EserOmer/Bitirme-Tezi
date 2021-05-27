using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Client.AuthDtos
{
    public class RegisterDto
    {
        [EmailAddress(ErrorMessage = "Geçerli bir e-mail giriniz.")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda; en az bir büyük, bir küçük ve bir adet özel karakter içermeli.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor!")]
        public string PasswordConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
