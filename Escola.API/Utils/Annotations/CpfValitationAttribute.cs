using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.API.Utils.Annotations
{

    public class CpfValitationAttribute : ValidationAttribute
    {
       
        public CpfValitationAttribute() : base() { }

        public override bool IsValid(object value)
        {
            return CpfValidacao.Validate(value.ToString());
        }



    }
}
