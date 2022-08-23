if (typeof (ViaCep) == "undefined") { ViaCep = {} }

ViaCep = {
	CepOnChange: function (executionContext) {
		var formContext = executionContext.getFormContext();

		var cep = formContext.getAttribute("address1_postalcode").getValue();
		var idcontato = Xrm.Page.data.entity.getId();


		var execute_new_ViaCep_Request = {
			// Parameters
			entity: { entityType: "contact", id: idcontato }, // entity
			CEP: cep, // Edm.String

			getMetadata: function () {
				return {
					boundParameter: "entity",
					parameterTypes: {
						entity: { typeName: "mscrm.contact", structuralProperty: 5 },
						CEP: { typeName: "Edm.String", structuralProperty: 1 }
					},
					operationType: 0, operationName: "new_ViaCep"
				};
			}
		};

		Xrm.WebApi.online.execute(execute_new_ViaCep_Request).then(
			function success(response) {
				if (response.ok) { return response.json(); }
			}
		).then(function (responseBody) {
			var result = responseBody;
			console.log(result);

			var sucesso = result["Sucesso"];
			var logradouro = result["Logradouro"];
			var complemento = result["Complemento"];
			var localidade = result["Localidade"];
			var bairro = result["Bairro"];
			var uf = result["UF"];
			var ibge = result["IBGE"];
			var ddd = result["DDD"];

			formContext.getAttribute("dyp_logradouro").setValue(logradouro);
			formContext.getAttribute("dyp_complemento").setValue(complemento);
			formContext.getAttribute("dyp_bairro").setValue(localidade);
			formContext.getAttribute("dyp_localidade").setValue(bairro);
			formContext.getAttribute("dyp_uf").setValue(uf);
			formContext.getAttribute("dyp_codigoibge").setValue(ibge);
			formContext.getAttribute("dyp_ddd").setValue(ddd);
		}).catch(function (error) {
			console.log(error.message);
		});
	}
}
