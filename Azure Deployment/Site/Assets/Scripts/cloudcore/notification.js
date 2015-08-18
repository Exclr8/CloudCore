$(document).ready(function () {
    registerHideErrorClick();

});

//Positioning and Animation Functions
var notificationShowAnimationTime = 400 //ms
var notificationHideAnimationTime = 400 //ms
var notificationHideDelayTime = 5000 //ms

function DoShowAnimation(err) {
    err.fadeOut(0).fadeIn(notificationShowAnimationTime);
}

function DoHideAnimation() {
    var win = (window.parent.document) ? window.parent.document : document;
    var err = $('#cError', win);
    err.fadeOut(notificationHideAnimationTime);
}

function DoPositionNotification(err, x, y) {
    err.css({
        'top': y,
        'right': '18px',
        'display': ''
    });

    return err;
}

//End Animation Code


function registerHideErrorClick() {
    $('#cError').on('click', function () {
        HideNotification($(this), false);
    });
}

function GlobalAjaxErrorHandler(e, jqxhr, settings, exception) {
    try {
        ShowError(exception == undefined ? e.statusText == 'error' ? 'An error has occurred, please try again shortly.' : e.statusText : exception);
    } catch (e) {
        ShowError('An error has occurred, please try again shortly');
    }
}

function getErrHeight(err) {
    return err.height() + (parseInt(err.css('padding-top')) + parseInt(err.css('padding-bottom'))) + 37;
}

function getErrWidth(err) {
    return err.width() + (parseInt(err.css('padding-left')) + parseInt(err.css('padding-right')));
}

var t;

function ShowNotify(message, title, msgType) {
    clearTimeout(t);
    var win = (window.parent.document) ? window.parent.document : document;
    var err = $('#cError', win);

    err.stop(true, true);
    var x = $(win).scrollTop();

    title = (title == undefined || title == '') ? msgType : title;

    DefineStyling(err, msgType, title);
    PopulateNotification(message, title);

    var errWidth = getErrWidth(err);
    var windowWidth = $(win).width();

    var vertPos = 45;
    var horPos = (windowWidth - errWidth) - 18;

    err = DoPositionNotification(err, horPos, vertPos);
    err.stop(true, true);

    DoShowAnimation(err);

    return err;
}

function DefineStyling(err, msgType, title) {
    var addClass = '', imgClass = '', titleClass = '';
    var isCloseOn = false;
    var msgClass = 'messageNotify', errClass = 'errNotify', successClass = "successNotify";
    var msgImgClass = 'messageNotifyImg', errImgClass = 'errNotifyImg', successImgClass = 'successNotifyImg';
    var messageTitleClass = 'messageNotifyTitle', errTitleClass = 'errNotifyTitle', successTitleClass = 'successNotifyTitle';

    if (msgType == 'Success') {
        addClass = successClass;
        isCloseOn = false;
        imgClass = successImgClass;
        titleClass = successTitleClass;
    } else if (msgType == 'Error') {
        addClass = errClass;
        isCloseOn = true;
        imgClass = errImgClass;
        titleClass = errTitleClass;
    } else if (msgType == 'Message') {
        addClass = msgClass;
        isCloseOn = true;
        imgClass = msgImgClass;
        titleClass = messageTitleClass;
    }

    title = (title == '' || title == undefined) ? msgType : title;
    err.removeClass(msgClass).removeClass(successClass).removeClass(errClass).addClass(addClass);
    $('.notifyBase .notifyImg').removeClass(msgImgClass).removeClass(errImgClass).removeClass(successImgClass).addClass(imgClass);
    $('.notifyBase .text .title').removeClass(messageTitleClass).removeClass(errTitleClass).removeClass(successTitleClass).addClass(titleClass);
    toggle($('.notifyBase .clickClose'), isCloseOn);
}

function PopulateNotification(message, title) {
    $('.notifyBase .text .notificationMessageContent').html(message);
    $('.notifyBase .text .title').html(title);
}

function ShowSuccess(message, title) {
    var err = ShowNotify(message, title, 'Success');
    HideNotification(err, true);
}

function ShowError(message, title) {
    ShowNotify(message, title, 'Error');
}

function ShowMessage(message, title) {
    ShowNotify(message, title, 'Message');
}

function HideNotification(err, withDelay) {
    if (withDelay) {
        t = setTimeout("DoHideAnimation()", notificationHideDelayTime);
        return;
    }

    DoHideAnimation(err);
}

function toggle(el, on) {
    el.css('display', (on) ? '' : 'none');
}