var Order = function () {
    var lineItems = [];
    this.addLineItem = function (lineItem) {
        lineItems.push(lineItem);
    };
    this.getDataForPost = function () {
        return JSON.stringify({
            LineItems: lineItems
        });
    };
    this.reset = function () {
        lineItems = [];
    };
};