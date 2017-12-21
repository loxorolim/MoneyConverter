function Quotation(name, symbol, value) {
    var self = this;
    self.currencyName = name;
    self.currencySymbol = symbol;
    self.value = value;

    self.formattedCurrency = function () {
        return self.currencySymbol + self.value.toString();
    };  
}

var indexViewModel = new function IndexViewModel () {

    var self = this;

    self.quotations = [
        new Quotation("Euro (EUR)", "€", 123),
        new Quotation("Euro (EUR)", "€", 123),
        new Quotation("Euro (EUR)", "€", 123),
        new Quotation("Euro (EUR)", "€", 123)
    ]; 

}

// Activates knockout.js
ko.applyBindings(indexViewModel);