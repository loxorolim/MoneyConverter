function Quotation(name, symbol, value) {
    var self = this;
    self.currencyName = name;
    self.currencySymbol = symbol;
    self.value = value;

    self.formattedCurrency = function () {
        return self.currencySymbol + " " + self.value.toString();
    };  
}

var indexViewModel = new function IndexViewModel () {

    var self = this;

    self.quotations = [
        new Quotation("Euro (EUR)", "€", 123),
        new Quotation("Great Britain Pound (GBP)", "£", 123),
        new Quotation("Japan Yen (JPY)", "¥", 123),
        new Quotation("Yuan (CNH)", "元", 123)
    ]; 

    self.updateValues = function () {

        $.get(
            "https://forex.1forge.com/1.0.2/quotes?pairs=EURUSD,GBPJPY,AUDUSD&api_key=YOUR_API_KEY",
            function (data) {
                alert(data);
            }
        );

    }

}

// Activates knockout.js
ko.applyBindings(indexViewModel);