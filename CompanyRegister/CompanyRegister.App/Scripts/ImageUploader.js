$(document).ready(function () {

    $("#imageBrowes").change(function () {

        var File = this.files;

        if (File && File[0]) {
            ReadImage(File[0]);
        }

    })

})


var ReadImage = function (file) {

    var reader = new FileReader;
    var image = new Image;

    reader.readAsDataURL(file);
    reader.onload = function (_file) {

        image.src = _file.target.result;
        image.onload = function () {

            var height = this.height;
            var width = this.width;
            var type = file.type;
            var size = ~~(file.size / 1024) + "KB";

            $("#targetImg").attr('src', _file.target.result);
            $("#description").text("Size:" + size + ", " + height + "X " + width + ", " + type + "");
            $("#imgPreview").show();

        }

    }

}

var ClearPreview = function () {
    $("#imageBrowes").val('');
    $("#description").text('');
    $("#imgPreview").hide();

}

var Uploadimage = function () {

    var file = $("#imageBrowes").get(0).files;

    var data = new FormData;
    data.append("ImageFile", file[0]);
    data.append("ProductName", "SamsungA8");

    $.ajax({

        type: "Post",
        url: "/Operator/ImageUpload",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            ClearPreview();

            $("#uploadedImage").append('<img src="/UploadedImage/' + response + '" class="img-responsive thumbnail"/>');


        }

    })



}