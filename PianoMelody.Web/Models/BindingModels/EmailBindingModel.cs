using PianoMelody.I18N;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PianoMelody.Web.Models.BindingModels
{
    public class EmailBindingModel
    {
        [Display(Name = "_Name", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [EmailAddress]
        [Display(Name = "_Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "_Phone", ResourceType = typeof(Resources))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "_Message", ResourceType = typeof(Resources))]
        public string Message { get; set; }
    }
}