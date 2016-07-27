$(document).ready(function () {

    function previewImages(input) {

        if (input.files) {

            for (var i = 0; i < input.files.length; i++) {
                var reader = new FileReader();

                reader.onload = function (e) {

                    var img = $('<img class="multiple-image">');
                    img.attr('src', e.target.result);
                    img.appendTo('#images-preview');

                }

                reader.readAsDataURL(input.files[i]);
            }
        }
    }

    $("#file").change(function () {
        $("#images-preview").empty();
        previewImages(this);
    });

});