using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVTheque.client.ViewModels
{
    public class ViewUser
    {
        private string _username;
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vius devez spécifier un nom d'utilisateur compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Nom d'utilisateur")]
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnValueChanged(null);
            }
        }
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vius devez spécifier un mot de passe compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Mot de passe")]
        public string Password { get; set; }
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vous devez spécifier un firstname compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Firstname")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "vius devez spécifier un lastname compris entre 3 et 30 caractères")]
        [DisplayName(displayName: "Lastname")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "le champs << {0} >> est obligatoire")]
        [EmailAddress(ErrorMessage = "vius devez spécifier un mail valide")]
        [DisplayName(displayName: "Email")]
        public string Mail { get; set; }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this,e);
        }
    }
}
