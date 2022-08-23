if (typeof (UperCaseName) == "undefined") { UperCaseName = {} }

UperCaseName = {
    NameOnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var nome = formContext.getAttribute("name").getValue();

        var loweredText = nome.toLowerCase();

        var palavras = loweredText.split(" ");

        for (var a = 0; a < palavras.length; a++) {
            var w = palavras[a];

            var firstLetter = w[0];
            w = firstLetter.toUpperCase() + w.slice(1);

            palavras[a] = w;
        }

        nameUp = palavras.join(" ");

        formContext.getAttribute("name").setValue(nameUp);

    }
}