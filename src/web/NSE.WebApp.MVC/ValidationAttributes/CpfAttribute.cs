using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.ValidationAttributes
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			=> Validar(value.ToString()) ? ValidationResult.Success : new ValidationResult("CPF em formato inválido");

        private static bool Validar(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf += digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito += resto.ToString();
			return cpf.EndsWith(digito);
		}
	}

	public class CpfAttributeAdapter : AttributeAdapterBase<CpfAttribute>
	{
		public CpfAttributeAdapter(CpfAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }

		public override void AddValidation(ClientModelValidationContext context)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			MergeAttribute(context.Attributes, "data-val", "true");
			MergeAttribute(context.Attributes, "data-val-cpf", GetErrorMessage(context));
		}

        public override string GetErrorMessage(ModelValidationContextBase validationContext) 
			=> "CPF em formato inválido";
    }

	public class CpfValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
	{
		private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();

		public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
		{
			if (attribute is CpfAttribute CpfAttribute)
				return new CpfAttributeAdapter(CpfAttribute, stringLocalizer);

			return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
		}
	}
}
