if (typeof (ValidarCNPJ) == "undefined") { ValidarCNPJ = {} }

TValidarCNPJ = {
    CNPJOnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var cnpj = formContext.getAttribute("dyp_cnpj").getValue();

        if (cnpj != null) {
            if (cnpj.length == 14) {
                var cnpjFormatado = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
                var id = Xrm.Page.data.entity.getId();

                var queryAccountId = "";

                if (id.length > 0) {
                    queryAccountId += " and accountid ne " + id;
                }

                Xrm.WebApi.online.retrieveMultipleRecords("account", "?$select=name&$filter=dyp_cnpj eq '" + cnpjFormatado + "'" + queryAccountId).then(
                    function success(results) {
                        if (results.entities.length == 0) {
                            formContext.getAttribute("dyp_cnpj").setValue(cnpjFormatado);
                        }
                        else {
                            formContext.getAttribute("dyp_cnpj").setValue("");
                            Tcc.Account.DynamicsAlert("Essa conta já existe no sistema. Por favor insira um outro CNPJ", "CNPJ Duplicado");
                        }
                    },
                    function (error) {
                        Tcc.Account.DynamicsAlert(error.message, "Error");
                    }
                );
            } else {
                Tcc.Account.DynamicsAlert("Por favor coloque um cnpj válido", "CNPJ Inválido");
                formContext.getAttribute("dyp_cnpj").setValue("");
            }
        }
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtonLabel: "OK",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            heigth: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    }
}

