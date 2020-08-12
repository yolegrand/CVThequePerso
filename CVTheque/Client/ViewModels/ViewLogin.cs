using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.Client.ViewModels
{
    public class ViewLogin
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

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}
