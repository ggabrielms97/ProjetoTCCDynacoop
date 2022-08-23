if (typeof (ClonarProposta) == "undefined") { ViaCep = {} }

ClonarProposta = {
	ClonarPropostaOnClick: function (executionContext) {

		var idoportunidade = Xrm.Page.data.entity.getId();


		var execute_new_ClonarProposta_Request = {
			// Parameters
			entity: { entityType: "opportunity", id: idoportunidade }, // entity

			getMetadata: function () {
				return {
					boundParameter: "entity",
					parameterTypes: {
						entity: { typeName: "mscrm.opportunity", structuralProperty: 5 }
					},
					operationType: 0, operationName: "new_ClonarProposta"
				};
			}
		};

		Xrm.WebApi.online.execute(execute_new_ClonarProposta_Request).then(
			function success(response) {
				if (response.ok) { console.log("Success"); }
			}
		).catch(function (error) {
			console.log(error.message);
		});

	}
}
