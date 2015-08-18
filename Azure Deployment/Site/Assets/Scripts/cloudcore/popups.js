var popupStatus = 0;
var currPopup = '';
var currPopupId = '';
var forceClose = false;
var popupFadeInTime = 600;
var popupFadeOutTime = 600;
var backgroundFadeInTime = 700;
var backgroundFadeOutTime = 700;

function setPopup(name, id) {
    currPopup = name;
    currPopupId = id;
}

function fixIframe(width, height) {
    var titleHeight = 57;
    $('#popupIFrame').css('height', (parseInt(height) - titleHeight) + 'px');
    $('#popupIFrame').css('width', width);
}

function loadPopup(url, width, height, popupName, title) {
    //loads popup only if it is disabled  
    if (popupStatus == 0) {
        fixIframe(width, height);
        //$('#popUp').css({ "width": width, "height": height });
        $('#popupIFrame').attr('src', url);

        $('#titleText').html(title);
        
        centerPopup($('#popUp'), popupName);
        onResizeWindow(popupName);
        doBackground();

        $('#popUp').css({ "z-index": "5999" });

        $('#popUp').fadeIn(popupFadeInTime);
        popupStatus = 1;

        //Hide notification not popup
        DoHideAnimation();
    }
}

function determineElement(el) {
    return (el == null || el == undefined) ? $(".popUpStructure") : el;
}

function unBindPopupCloseClick() {
    $('.popCloseButton').die('click');
}

function BindPopupClickStandard() {
    $('.popCloseButton').on('click', function () {
        disablePopup();
    });
}

function checkForceClose() {
    if (forceClose == true)
        disablePopup();
}


function onResizeWindow(popupName) {
    $(window).resize(function () {
        centerPopup($('#popUp'), popupName);
    });
}

function disablePopup(el) {
    el = determineElement(el);

    //disables popup only if it is enabled  
    if (popupStatus == 1) {
        //$('body').css('overflow', 'visible');
        $("#backgroundPopup").fadeOut(backgroundFadeOutTime);

        el.fadeOut(popupFadeOutTime);
        popupStatus = 0;

        if ($('#popupIFrame').length > 0) {
            $('#popupIFrame').attr('src', '');
        }

        if (currPopup != undefined && currPopup != '') {
            //scripts specified in ipopupiniator
            eval('close' + currPopup + 'Popup()');
            setPopup('', '');
        }
    }
}

//centering popup  
function centerPopup(el, popupName) {
    el = determineElement(el);

    setPopup(popupName, el.attr('id'));

    //request data for centering  
    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    var popupHeight = el.height();
    var popupWidth = el.width();
    //centering  
    el.css({
        "position": "fixed",
        "top": (windowHeight - popupHeight) / 2,
        "left": (windowWidth - popupWidth) / 2
    });
}

function doBackground() {
    $("#backgroundPopup").css({
        "opacity": "0.7",
        "z-index": "5998",
        "height": screen.height
    });
    $("#backgroundPopup").fadeIn(backgroundFadeInTime);
}

function setLookUpControlValues(idTextBoxName, idValue, valueTextBoxName, nameValue)
{
    $('#' + idTextBoxName).val(idValue);
    $('#name_' + valueTextBoxName).val(nameValue);
    $('#' + valueTextBoxName).val(nameValue);
    $('#modal-container').modal('hide');
    disablePopup();
}

function setModalLookUpControlValues(idTextBoxName, idValue, valueTextBoxName, nameValue) {
    $('#' + idTextBoxName).val(idValue);
    $('#name_' + valueTextBoxName).val(nameValue);
    $('#input_' + valueTextBoxName).val(nameValue);
    $('#modal-container').modal('hide');
}
