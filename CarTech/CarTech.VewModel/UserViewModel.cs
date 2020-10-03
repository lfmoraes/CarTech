using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarTech.ViewModel
{
    public class UserViewModel
    {
        [DisplayName("Código")]
        public string Id { get; set; }

        [DisplayName("Nome")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
