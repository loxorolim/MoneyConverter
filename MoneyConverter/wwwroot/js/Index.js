function Quotation(name, abbreviation, symbol, value) {
    var self = this;
    self.currencyName = name;
    self.currencyAbbreviation = abbreviation;
    self.currencySymbol = symbol;
    self.value = ko.observable(value);


    self.fullName = function () {
        return self.currencyName + " (" + self.currencyAbbreviation + ")" 
    };

    self.formattedCurrency = function () {
        return self.currencySymbol + " " + self.value().toString();
    };  
}

var indexViewModel = new function IndexViewModel () {

    var self = this;

    self.inputAmount = ko.observable();

    self.quotations = ko.observableArray([
        new Quotation("Euro", "EUR", "€", 0),
        new Quotation("Great Britain Pound","GBP", "£", 0),
        new Quotation("Japan Yen", "JPY", "¥", 0),
        new Quotation("Yuan", "CNH", "元", 0)
    ]); 

    self.inputQuotation = ko.observable(self.quotations()[0]);
    self.outputQuotation = ko.observable(self.quotations()[0]);

    self.updateValues = function () {

        $.get(
            "https://forex.1forge.com/1.0.2/quotes?pairs=USDEUR,USDGBP,USDJPY,USDCNH&api_key=Yer9o3wICwhKlviLU0zZGavH9AGZuqd3",
            function (data) {
                for (i = 0; i < data.length; i++) {
                    self.quotations()[i].value(data[i].price);
                }
            }
        );
    }

    self.updateValues();
    setInterval(self.updateValues, 30000);
    
}

// Activates knockout.js
ko.applyBindings(indexViewModel);