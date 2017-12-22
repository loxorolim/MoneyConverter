function Currency(name, abbreviation, symbol, value) {
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

    self.quotations = []

    self.currencies = [
        new Currency("Euro", "EUR", "€", 0),
        new Currency("Great Britain Pound","GBP", "£", 0),
        new Currency("Japan Yen", "JPY", "¥", 0),
        new Currency("Yuan", "CNH", "元", 0),
        new Currency("United States Dollar", "USD", "$", 0)
    ]; 

    self.inputAmount = ko.observable();
    self.outputAmount = ko.observable();

    self.inputCurrency = ko.observable(self.currencies[0]);
    self.outputCurrency = ko.observable(self.currencies[0]);

    self.fetchQuotations = function () {

        var pairs = "pairs=";

        for (i = 0; i < self.currencies.length; i++) {
            for (j = 0; j < self.currencies.length; j++) {
                pairs += self.currencies[i].currencyAbbreviation + self.currencies[j].currencyAbbreviation + ",";
            }
        }

        var url = "https://forex.1forge.com/1.0.2/quotes?" + pairs + "&api_key=Yer9o3wICwhKlviLU0zZGavH9AGZuqd3";

        $.ajax({
            url: url,
            type: "get",
            async: false,
            success: function (data) {
                self.quotations = data;
            }
        });
    }

    self.updateQuotations = function () {

        self.fetchQuotations();

        for (i = 0; i < self.currencies.length; i++) {
            for (j = 0; j < self.quotations.length; j++) {
                if (self.quotations[j].symbol == ("USD" + self.currencies[i].currencyAbbreviation)) {
                    self.currencies[i].value(self.quotations[j].price);
                }
            }
        }
    }

    self.updateQuotations();
    setInterval(self.updateQuotations, 30000);
    
}

// Activates knockout.js
ko.applyBindings(indexViewModel);