(function ($) {
    "use strict";

    // Dropdown on mouse hover
    $(document).ready(function () {
        function toggleNavbarMethod() {
            if ($(window).width() > 992) {
                $('.navbar .dropdown').on('mouseover', function () {
                    $('.dropdown-toggle', this).trigger('click');
                }).on('mouseout', function () {
                    $('.dropdown-toggle', this).trigger('click').blur();
                });
            } else {
                $('.navbar .dropdown').off('mouseover').off('mouseout');
            }
        }
        toggleNavbarMethod();
        $(window).resize(toggleNavbarMethod);
    });


    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1500, 'easeInOutExpo');
        return false;
    });


    // Vendor carousel
    $('.vendor-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0: {
                items: 2
            },
            576: {
                items: 3
            },
            768: {
                items: 4
            },
            992: {
                items: 5
            },
            1200: {
                items: 6
            }
        }
    });


    // Related carousel
    $('.related-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            }
        }
    });
    
    // Product Quantity
    $('.quantity button').on('click', function () {
        var firstprices = $("#TotalPrices").val();
        var button = $(this);
        var defaultQuantity = button.parent().parent().find('input').val();
        if (button.hasClass('btn-plus')) {
            var newValue = parseFloat(defaultQuantity) + 1;
        }
        else
        {
            var newValue = parseFloat(defaultQuantity) - 1;
            if (newValue < 1) {
                newValue = 1;
            }
        }

        button.parent().parent().find('input').val(newValue).attr("value", newValue);
        var ProductPrice = button.parent().parent().find('li').val();
        var price = (newValue * ProductPrice);
        var top = (firstprices + ProductPrice);
        console.log("Total Price", firstprices);
        console.log("product price", ProductPrice);
        console.log("top", top);
        console.log("quanti * price", price);


        //firstprices = parseFloat((ProductPrice + firstprices)); 
        //$("#TotalPrices").attr("value", firstprices);
        document.getElementById("TotalPrices").innerHTML = top;

        //$("#TotalPrice").attr("value", firstprices);
        //document.getElementById("TotalPrice").innerHTML = firstprices;

    });

    
})(jQuery);

