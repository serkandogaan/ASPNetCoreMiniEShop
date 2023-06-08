/*const { post } = require("jquery");*/

$("#AddProduct").click(function () {

    var input = document.getElementById("imageFile");
    var imageFile = input.files;
    var formData = new FormData();

    for (var i = 0; i != imageFile.length; i++) {
        formData.append("imageFile", imageFile[i]);
    }

    formData.append("ProductName", $("#validationCustom01").val());
    formData.append("ProductCategoryID", $("#validationCustom02").val());
    formData.append("ProductDescription", $("#mytextarea").val());
    formData.append("ProductPrice", $("#validationCustom03").val());
    formData.append("ProductColor", $("#validationCustom04").val());
    formData.append("ProductSize", $("#validationCustom05").val());

    $.ajax({

        type: "post",
        url: '/Product/AddProduct/',
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


$("#AddProductCategory").click(function () {

    var ProductCategory = {
        ProductCategoryName: $("#validationCustom01").val(),
        ProductCategoryDescription: $("#validationCustom02").val(),       
    };

    $.ajax({
        type: "post",
        url: "/Product/AddProductCategory/",
        data: ProductCategory,
        success: function () {
            swal({
                title: "Good job!",
                text: "You clicked the button!",
                icon: "success",
                button: "Aww yiss!",
            });
        },
        error: function (err) {
            var hata = err.status + ' : ' + err.statusText
            alert("Not Added" + hata)
        },
    });

});






// ------- AJAX POST İŞLEMİ ----------


//$("#AddProducts").click(function () {

//    var Product = {
//        ProductName: $("#validationCustom01").val(),
//        ProductCategoryID: $("#validationCustom02").val(),
//        ProductDescription: $("#mytextarea").val(),
//        ProductPrice: $("#validationCustom03").val(),
//        ProductColor: $("#validationCustom04").val(),
//        ProductSize: $("#validationCustom05").val(),
//    };

//    //var input = document.getElementById("imageFile");
//    //var imageFile = input.files;
//    //var formData = new FormData();   


//    //for (var i = 0; i != imageFile.length; i++) {
//    //    formData.append("imageFile", imageFile[i]);
//    //}

//    $.ajax({

//        type: "post",
//        url: '/Product/AddProduct/',
//        data: Product,
//        success: function () {
//            alert("Added")
//        },
//        error: function (error) {
//            var hata = error.status + ' : ' + error.statusText
//            alert("Not Added" + hata)
//        }
//    });
//});