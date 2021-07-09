$(function () {
    $('.blankCustomerElement').on('click', function () {
        $('[id*="customerName"]').val($(this).text());
    });

    $('[id*="customerName"]').on('blur', function () {
        setTimeout(function () {
            EmptyAndHideCustomerList();
        }, 150);
    });

    $('[id*="customerName"]').on('input', function () {
        var userInput = $(this).val();

        if (userInput) {
            var settings = {
                "url": "https://localhost:44303/api/orders/customers/names/" + userInput,
                "method": "GET",
                "timeout": 0,
            };

            $.ajax(settings)
                .done(function (response) {
                    if (response.length > 0) {
                        //call a function to add to the customer list
                        SetCustomerList(response);
                    } else {
                        //call a function to empty the list and hide it
                        EmptyAndHideCustomerList()
                    }
                })
                .fail(function (response) {
                    //call a function to empty the list and hide it
                    EmptyAndHideCustomerList()
                });
        } else {
            //call a function to empty the list and hide it
            EmptyAndHideCustomerList()
        }
    });

    function SetCustomerList(arr) {
        var customerSearchObject = $('[id*="CustomerSearch"]');
        var customerList = customerSearchObject.find('[id*="CustomerList"]');
        var blankCustomer = customerSearchObject.find('[id*="BlankCustomer"]');

        //erase the customer list
        customerList.empty();

        arr.forEach(s => {
            var theClone = blankCustomer.clone(true);

            theClone.prop('id', 'newCustomer');
            theClone.removeClass('d-none');
            theClone.text(s);
            theClone.appendTo(customerList);
        });

        if (arr.length > 0) {
            customerSearchObject.removeClass('d-none');
            blankCustomer.addClass('d-none');
        } else {
            //call a function to empty the list and hide it
            EmptyAndHideCustomerList()
        }
    }

    function EmptyAndHideCustomerList() {
        var customerSearchObject = $('[id*="CustomerSearch"]');
        var customerList = customerSearchObject.find('[id*="CustomerList"]');
        customerList.empty();
        customerSearchObject.addClass('d-none');
    }
});