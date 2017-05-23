(function () {

    var CONSTANTS = {
        API_URL: 'http://localhost:57535/',
        DISPLAY: {
            INSERT_COIN: 'INSERT COIN',
            THANK_YOU: 'THANK YOU',
            PRICE: 'PRICE'
        }
    };


    var vendingMachine = new Vue({
        el: '#vendingMachine',
        data: {
            products: [],
            coins: initCoins(),
            display: 'INSERT COIN',
            insertingCoin: null,
            refundedCoins: [],
            movingCoin: null
        },
        methods: {
            insertCoin: function () {
                var coin = vendingMachine.movingCoin;
                //vendingMachine.display = CONSTANTS.DISPLAY.INSERT_COIN;
                vendingMachine.refundedCoins = [];

                // don't add more than one coin at a time
                this.insertingCoin = true;

                fetch(CONSTANTS.API_URL + 'coin/insert/', {
                    method: 'POST',
                    body: JSON.stringify({
                        weight: coin.weight,
                        thickness: coin.thickness,
                        diameter: coin.diameter,
                    }),
                    headers: {
                        "Content-Type": "application/json"
                    }
                }).then(function (r) {
                    return r.json();
                })
                    .then(function (json) {
                        vendingMachine.display = '$' + Number(json / 100).toFixed(2);
                        vendingMachine.insertingCoin = false;
                        vendingMachine.movingCoin = null;
                    });


            },
            refund: function () {
                fetch(CONSTANTS.API_URL + 'coin/refund/', {
                    method: 'GET'
                }).then(function (r) {
                    return r.json();
                })
                    .then(function (json) {
                        if (json) {
                            vendingMachine.refundedCoins = formatRefundedCoins(json);
                        } else {
                            vendingMachine.refundedCoins = [];
                        }
                        vendingMachine.display = CONSTANTS.DISPLAY.INSERT_COIN;
                        initCoinDropDragAndDrop();
                    });
            },
            vend: function (product) {
                vendingMachine.refundedCoins = [];
                fetch(CONSTANTS.API_URL + 'product/vend/' + product.id, {
                    method: 'GET'
                }).then(function (r) {
                    return r.json();
                })
                    .then(function (json) {
                        if (json.productPrice) {
                            vendingMachine.display = CONSTANTS.DISPLAY.PRICE + ' $' + formatToTwoDecimalPlaces(json.productPrice / 100);
                        }

                        if (json.returnedCoins) {
                            vendingMachine.display = CONSTANTS.DISPLAY.THANK_YOU;
                            vendingMachine.refundedCoins = formatRefundedCoins(json.returnedCoins);
                            initCoinDropDragAndDrop();
                        }
                    });
            }
        }
    })

    initVendingMachine();

    function formatRefundedCoins(coins) {
        coins.forEach(function (coin) {
            coin = formatToTwoDecimalPlaces(coin);
        });

        return coins;
    }

    function formatToTwoDecimalPlaces(number) {
        return Number(number).toFixed(2);
    }

    function initVendingMachine() {
        fetch(CONSTANTS.API_URL + 'state/current/', {
            method: 'GET'
        }).then(function (r) {
            return r.json();
        })
            .then(function (json) {

                json.products.forEach(function (product) {
                    product.formattedPrice = '$' + formatToTwoDecimalPlaces(product.price / 100);
                });
                vendingMachine.products = json.products;
                if (json.valueOfCoinsInMachine) {
                    vendingMachine.display = '$' + formatToTwoDecimalPlaces(json.valueOfCoinsInMachine / 100);
                } else {
                    vendingMachine.display = CONSTANTS.DISPLAY.INSERT_COIN;
                }
                initCoinsDragAndDrop();
                initCoinDropDragAndDrop();
            });
    }

    function initCoinsDragAndDrop() {

        Sortable.create(document.querySelector(".js-coins"), {
            group: {
                name: 'vendingMachineCoins',
                pull: 'clone',
                put: false
            },
            sort: false,
            onStart: function () {
                toggleCoinDropHighlight();
            },
            onEnd: function () {
                toggleCoinDropHighlight();
            },
            onMove: function (evt, originalElement) {


            },
            onClone: function (/**Event*/evt) {
                vendingMachine.movingCoin = vendingMachine.coins.filter(function (c) {
                    
                    return evt.clone.className.indexOf(c.name) > -1;
                })[0];

            }
        });
    }

    function initCoinDropDragAndDrop() {
        var coinDrop = document.querySelector(".js-vending-machine-money-drop");
        coinDrop.innerHTML = 'Drag monies here';
        Sortable.create(coinDrop, {
            group: {
                name: 'vendingMachineCoins',
                pull: false,
                put: true
            },
            onAdd: function (evt) {
                vendingMachine.insertCoin();
            }
        });

    }

    function toggleCoinDropHighlight() {
        var coinDrop = document.querySelector('.vending-machine-money-drop');
        if (coinDrop) {
            coinDrop.classList.toggle('highlight');
        }
    }

    function initCoins() {
        var coins = [];
        coins.push({
            name: 'Penny',
            diameter: 19.05,
            thickness: 1.55,
            weight: 2.5
        });
        coins.push({
            name: 'Nickel',
            diameter: 21.20,
            thickness: 1.95,
            weight: 5
        });
        coins.push({
            name: 'Dime',
            diameter: 17.9,
            thickness: 1.35,
            weight: 2.27
        });
        coins.push({
            name: 'Quarter',
            diameter: 24.26,
            thickness: 1.75,
            weight: 5.67
        });

        return coins;
    }



})();