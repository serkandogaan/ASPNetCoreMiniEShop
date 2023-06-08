/*const { data } = require("jquery");*/

$("#RegisterFormButton").click(function () {

    var User = {
        UserMail: $("#email").val(),
        UserPassword: $("#password").val(),
    };

    $.ajax({
        type: "post",
        url: '/Register/Register/',
        data: User,
        success: function () {
            alert("Registered")
        },
        error: function (error) {
            var hata = error.status + ' : ' + error.statusText
            alert("Not Registered" + hata)
        }
    });
});



    
//$('#Filter').click(function () {

//    var formData = new FormData();
//    var filterprice = [];
//    var filtercolor = [];
//    var filtersize = [];

//    $("input[name=filterprice]:checked").each(function () {
//        filterprice.push($(this).val());
//    });

//    $("input[name=filtercolor]:checked").each(function () {
//        filtercolor.push($(this).val());
//    });

//    $("input[name=filtersize]:checked").each(function () {
//        filtersize.push($(this).val());
//    });
  
//    for (var i = 0; i < filterprice.length; i++) {
//        formData.append('filterprice[]', filterprice[i]);
//    }

//    for (var i = 0; i < filtercolor.length; i++) {
//        formData.append('filtercolor[]', filtercolor[i]);
//    }

//    for (var i = 0; i < filtersize.length; i++) {
//        formData.append('filtersize[]', filtersize[i]);
//    }
    
//    $.ajax({
//        type: "post",
//        url: "/Home/Product/",
///*        traditional: true,*/
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function (data) {
//            console.log("success" + data);
//        },
//        error: function () {
//            console.log("fail" + data);
//        }
//    });   
//}) 


//$("#Filter").click(function () {

//    //var categoryId = $(this).attr("data-categoryId");
    
//    var arrayListPrice = [];
//    var arrayListColor = [];
//    var arrayListSize = [];

//    var filterprice = [];
//    var filtercolor = [];
//    var filtersize = [];

//    $("input[name=filterprice]:checked").each(function () {
//        filterprice.push($(this).val());
//    });

//    $("input[name=filtercolor]:checked").each(function () {
//        filtercolor.push($(this).val());
//    });

//    $("input[name=filtersize]:checked").each(function () {
//        filtersize.push($(this).val());
//    });

//    //var formData = new FormData();
//    //for (var i = 0; i < arrayListPrice.length; i++) {
//    //    formData.append('filterprice[]', arrayListPrice[i]);
//    //}

//    //for (var i = 0; i < arrayListColor.length; i++) {
//    //    formData.append('filtercolor[]', arrayListColor[i]);
//    //}

//    //for (var i = 0; i < arrayListSize.length; i++) {
//    //    formData.append('filtersize[]', arrayListSize[i]);
//    //}

//    //formData.append("categoryId", categoryId);

//    $.ajax({
//        type: "get",
//        url: '/Home/Product/',
//        data: filtercolor,
///*        contentType: false,*/
//        /*processData: false,*/
//        success: function (data) {
//            alert("getted")
//            console.log(data)
//        },
//        error: function (error) {
//            var hata = error.status + ' : ' + error.statusText + ' '
//            alert("not getted " + hata)
            
//            console.log(filtercolor)
//        }
//    });

//});





//$(".custom-control-input").click(function () {


//    //var values = document.getElementsByClassName(".custom-control-input");
//    //var formData = new FormData();

//    //for (var i = 0; i != values.length; i++) {
//    //    formData.append("filtercolor", Filter[i]);
//    //    //formData.append("filterprice", Filter[i]);
//    //    //formData.append("filtercolor", Filter[i]);
//    //    //formData.append("filtersize", Filter[i]);
//    //}

//    $('input[type="checkbox"].custom-control-input').each(function () {
//        console.log($(this).val());
//    });

//    $.ajax({

//        type: "get",
//        url: '/Home/Product/',
//        data: formData,
//        contentType: false,
//        processData: false,
//        success: function () {
//            alert("getted")
//            console.log('s')
//        },
//        error: function (error) {
//            var hata = error.status + ' : ' + error.statusText + ' '
//            alert("not getted" + hata)
//            console.log(formData.values)
//        }

//    });
//});


$("#AddProductReview").click(function () {

    var formData = new FormData();
  
    formData.append("ReviewerComment", $("#message").val());
    formData.append("ReviewerName", $("#name").val());
    formData.append("ReviewerMail", $("#email").val());

    $.ajax({

        type: "post",
        url: '/Home/AddProductReview/',
        data: formData,
        contentType: false,
        processData: false,
        success: function () {
            alert("Added")
        },
        error: function (error) {
            var hata = error.status + ' : ' + error.statusText
            alert("Not Added" + hata)
        }
    });

});

$("#AddProductToBasket").click(function () {

    var formData = new FormData();

    formData.append("ProductID", $("#ProductID").val());
    formData.append("ProductQuantity", $("#ProductID").val());



    $.ajax({

        type: "post",
        url: '/Home/InsertProductToBasket/',
        data: formData,
        contentType: false,
        processData: false,
        success: function () {
            alert("added")
        },
        error: function () {
            alert("not added")
        },
    });

});

$("#QuantityPlus").click(function () {

    //var QuantityValue = $("#QuantityValue").val();
    //var ProductPrice = 650;
    //var NewPrice = (1 + 1) * ProductPrice;



        $.ajax({
            type: "get",
            url: '/Home/CartPage/',
            data: NewPrice,
            success: function (data) {
                $('#TotalPrice').val(data);
            }
        });

});


//$(document).ready(function () {
//    $('.minus').click(function () {
//        var input = $("quantiy").val();
//        var count = input - 1;
//        count = count < 1 ? 1 : count;
//        input.val(count);
//        $("#quantiy").attr("value", count);
//        input.change();
//        return false;
//    });
//    $('.plus').click(function () {
//        var input = $("quantiy").val();
//        input.val(parseInt(input.val()) + 1);
//        $("#quantiy").attr("value", input.val());
//        input.change();
//        return false;
//    });
//});

