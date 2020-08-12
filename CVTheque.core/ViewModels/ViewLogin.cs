using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVTheque.core.ViewModels
{
    public class ViewLogin
    {
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vius devez spécifier un nom d'utilisateur compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Nom d'utilisateur")]
        public string Username { get; set; }
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vius devez spécifier un mot de passe compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Mot de passe")]
        public string Password { get; set; }
    }
}
