function loadLocalTemplate(TemplateUrl, onLoaded) {
    $.ajax({ url: TemplateUrl, isLocal: false })
                   .success(function (templates) {
                       $('body').append(templates);
                       if (onLoaded != null) { onLoaded(); }
                   });
}


function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

function makeAjaxCall(ajaxUrl, functionSuccess, functionFailure) {
    $.ajax(
    {
        type: "GET",
        url: ajaxUrl,
        contentType: "application/json; charset=utf-8",
        data: {},
        dataType: "json",
        success: functionSuccess,
        error: functionFailure
    });
}

function formatCurrency(value) {
    value = value.toFixed(2);

    return "R " + addCommas(value);
}

function SwopImage(element, imgcheck, imageA, imageB) {
    document.getElementById(element).src = (document.getElementById(element).src.indexOf(imgcheck) > 0) ? document.getElementById(element).src = imageB : document.getElementById(element).src = imageA
}

function ShowHideElement(element) {
    document.getElementById(element).style.display = document.getElementById(element).style.display == 'none' ? '' : 'none'
}

function strEndsWith(str, suffix) {
    return str.match(suffix + "$") == suffix;
}

function ValidateFileTypes(el) {
    if (el.attr("filetype")) {
        var currentextensions = el.attr("filetype");
        var extenstions = currentextensions.split("\|");
        var filename = el.val();
        var allowedtypes = "";
        var fileallowed = false;

        if (currentextensions != "*.*") {
            $.each(extenstions, function () {
                if (strEndsWith(filename.toLowerCase(), this.toString().toLowerCase())) {
                    fileallowed = true;
                }
                allowedtypes = allowedtypes + "." + this.toString() + ", ";
            });

            if (!fileallowed) {
                ShowError("Invalid File Type!<br/> Only " + allowedtypes.substring(0, (allowedtypes.length - 2)) + " file types allowed.", "Error...");
            }

            return fileallowed;
        } else {
            return true;
        }
    }
}

function BindEncType(el) {
    var form = el.parents('form');

    if (form.attr('enctype'))
        return;

    form.attr('enctype', 'multipart/form-data');
}

function RegisterStandardFileInput(name) {
    $(document).ready(function () {
        var element = $("#" + name);

        element.on("change", function () {
            if (!ValidateFileTypes($(this))) {
                if ($.browser.msie) {
                    element.replaceWith(element.clone());
                }
                else {
                    element.val('');
                }
            }
        });

        BindEncType(element);
    });
}

function intialiseDatePickerDateRange(selector, which, year, month, day) {
    $(selector).ready(function () {
        $(selector).datepicker('option', which, new Date(year, month - 1, day));
    });
}

function initialiseDisableSubmit(applicationRootPath) {

    var submitButton = $('input[type="submit"]').not(".excludegif");
    var loginButton = $('.loginbutton');

    submitButton.removeAttr('disabled');
    loginButton.removeAttr('disabled');

    if (applicationRootPath.substring(applicationRootPath.length - 1, 1) != '/') {
        applicationRootPath = applicationRootPath + '/';
    }

    //submitButton.after('<img src="' + applicationRootPath + 'asset/Get?file=/submitWait.gif&resourceArea=CUI" class="loadingImg" style="display:none;" />');

    submitButton.on('click', function () {
        //var img = $(this).next('.loadingImg');
        //var width = $(this).outerWidth();
        //var height = $(this).outerHeight();
        //var position = $(this).position();
        //var imgWidth = img.width();
        //var imgHeight = img.height();

        //img.css('left', position.left + ((width - imgWidth) / 2) + 'px');
        //img.css('top', position.top + ((height - imgHeight) / 2) + 'px');
        //img.css('padding', '0');
        //img.css('margin', '0');
        //img.css('display', 'block');

        //$(this).css('width', width + 'px');
        $('.submit-btn-container').addClass('submit-btn-loader');
        $(this).attr('data-val-orig', $(this).val());
        $(this).attr('disabled', 'disabled');
        //$(this).val(' ');

        if ($(this).parents('form[data-ajax="true"]').length == 0)
            $(this).parents('form').submit();
    });

}

function enableSubmit(selector) {
    var el = $(selector);
    var img = el.next('.loadingImg');
    img.css('display', 'none');
    el.removeAttr('disabled');
    el.val(el.attr('data-val-orig'));

    setTimeout(function() {
        $('.submit-btn-container').removeClass('submit-btn-loader');
    }, 500);        
}

//TODO: Remove this and fix breaking changes...
function initFormsForBootstrap() {
    $("form").addClass('form-horizontal')
             .attr('role', 'form');
}

$(document).ready(function () {

    $('.datefield').datepicker({
        dateFormat: 'yy/mm/dd',
        showOn: 'button',
        buttonImage: "../../../asset/Get?file=datepicker/datepicker.gif&resourceArea=CUI",
        buttonImageOnly: true,
        changeMonth: true,
        changeYear: true
    });

    initFormsForBootstrap();

    $("form").submit(function () {
        if (!$(this).valid()) {
            enableSubmit($('form input[type="submit"]'));
            return false;
        }

        return true;
    });

});

//pads left
String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}

//pads right
String.prototype.rpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = str + padString;
    return str;
}





