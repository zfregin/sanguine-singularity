var initialData = [
    { name: "Crocs", inventory: 38, price: 29.99 },
    { name: "Gucci Belt", inventory: 12, price: 350.00 },
    { name: "Clout Goggles", inventory: 317, price: 15.99 },
    { name: "Supreme Shirt", inventory: 30, price: 40.00 },
    { name: "Thrasher Sweatshirt", inventory: 25, price: 50.00 },
    { name: "Yeezys", inventory: 5, price: 1500.00},
    { name: "Fidget Spinner", inventory: 623, price: 8.00 }
];


var PagedGridModel = function (items) {
    this.items = ko.observableArray(items);

    this.addItem = function () {
        this.items.push({ name: "New item", inventory: 0, price: 100 });
    };

    this.sortByName = function () {
        this.items.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
    };

    this.jumpToFirstPage = function () {
        this.gridViewModel.currentPageIndex(0);
    };

    this.gridViewModel = new ko.simpleGrid.viewModel({
        data: this.items,
        columns: [
            { headerText: "Item Name", rowText: "name" },
            { headerText: "Inventory", rowText: "inventory" },
            { headerText: "Price", rowText: function (item) { return "$" + item.price.toFixed(2) } }
        ],
        pageSize: 4
    });
};


ko.applyBindings(new PagedGridModel(initialData));