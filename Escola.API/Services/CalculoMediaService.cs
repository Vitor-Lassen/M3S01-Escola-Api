using Escola.API.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Escola.API.Services
{
    public class CalculoMediaService
    {

        public CalculoMediaService()
        {
          
        }

        public double CalcularMedia(params double[] notas)
        {
            double soma = 0;
            foreach (var nota in notas)
            {
                if (nota >= 0 && nota <= 10)
                    soma += nota;
                else
                    throw new ArgumentOutOfRangeException($"A nota {nota} deve ser maior ou igual a zero");
            }
            return soma / notas.Count();
        }
    }
}
