if (typeof (NoEdit) == "undefined") { NoEdit = {} }

NoEdit = {
    ProductOnLoad: function (executionContext) {
        //Capturar o Contexto
        var formContext = executionContext.getFormContext();

        var oportunidade = formContext.getAttribute("dyp_integracao").getValue();

        if (oportunidade == true) {
            formContext.getControl("name").setDisabled(true)
            formContext.getControl("parentcontactid").setDisabled(true)
            formContext.getControl("parentaccountid").setDisabled(true)
            formContext.getControl("purchasetimeframe").setDisabled(true)
            formContext.getControl("transactioncurrencyid").setDisabled(true)
            formContext.getControl("budgetamount").setDisabled(true)
            formContext.getControl("purchaseprocess").setDisabled(true)
            formContext.getControl("msdyn_forecastcategory").setDisabled(true)
            formContext.getControl("description").setDisabled(true)
            formContext.getControl("dyp_integracao").setDisabled(true)
            formContext.getControl("currentsituation").setDisabled(true)
            formContext.getControl("customerneed").setDisabled(true)
            formContext.getControl("proposedsolution").setDisabled(true)
            formContext.getControl("pricelevelid").setDisabled(true)
            formContext.getControl("isrevenuesystemcalculated").setDisabled(true)
            formContext.getControl("discountpercentage").setDisabled(true)
            formContext.getControl("discountamount").setDisabled(true)
            formContext.getControl("freightamount").setDisabled(true)
        }



    }
}