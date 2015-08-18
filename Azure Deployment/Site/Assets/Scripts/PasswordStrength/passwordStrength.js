/*
* Password Strength (0.1.4)
* by Sagie Maoz (n0nick.net)
* n0nick@php.net
*
* This plugin will check the value of a password field and evaluate the
* strength of the typed password. This is done by checking for
* the diversity of character types: numbers, lowercase and uppercase
* letters and special characters.
*
* Copyright (c) 2010 Sagie Maoz <n0nick@php.net>
* Licensed under the GPL license, see http://www.gnu.org/licenses/gpl-3.0.html 
*
*
* NOTE: This script requires jQuery to work.  Download jQuery at www.jquery.com
*
*/



function RegisterPassword(passwordCtlId, btnSubmitId, requiredStrength) {
    var arr = initialisePassword(passwordCtlId, btnSubmitId, requiredStrength);
    registerPasswordKeyUp(passwordCtlId, btnSubmitId, requiredStrength, arr);
    registerHideHelpLayer();
}

function initialisePassword(passwordCtlId, btnSubmitId, requiredStrength) {
    var options = new Array(
        { 'Id': 0, 'Text': 'Very Weak', 'Class': 'password_strength_0' },
        { 'Id': 1, 'Text': 'Weak', 'Class': 'password_strength_1' },
        { 'Id': 2, 'Text': 'Medium', 'Class': 'password_strength_2' },
        { 'Id': 3, 'Text': 'Strong', 'Class': 'password_strength_3' },
        { 'Id': 4, 'Text': 'Very Strong', 'Class': 'password_strength_4' }
    );
    return options;
}

function registerHideHelpLayer() {
    $('#helpClick').on("click", function () {
        showHelpLayer();
    });
}

function showHelpLayer() {
    var hC = $('#helpLayer');

    if (hC.css('display') == 'none') {
        hC.fadeIn('fast');
    } else {
        hC.fadeOut('fast');
    }
}

function registerPasswordKeyUp(passwordCtlId, btnSubmitId, requiredStrength, strengthArray) {

    $('#' + passwordCtlId).keyup(function (e) {
        var val = $(this).val();
        var level = passwordStrength.getStrengthLevel(val, 8);

        for (i = 0; i < 5; i++) {
            var psDiv = $('.password_strength div')[i];

            if (val == "") {
                $(psDiv).removeClass(strengthArray[i].Class);
                $('#pstext').html("&nbsp;");
            } else if ($(psDiv).attr('strength') < level) {
                $(psDiv).addClass(strengthArray[i].Class);
                $('#pstext').html(strengthArray[level - 1].Text);
            } else {
                $(psDiv).removeClass(strengthArray[i].Class);
                $('#pstext').html(strengthArray[level - 1].Text);
            }
        }
        $('#' + passwordCtlId).focusout(function () {
            if (passwordStrength.getStrengthLevel($('#' + passwordCtlId).val(), 8) < requiredStrength) {
                ShowError('Please select a password with a strength of ' + strengthArray[requiredStrength - 1].Text + ' or greater.');
                $('#' + btnSubmitId).attr('disabled', 'disabled');
            } else {
                $('#' + btnSubmitId).removeAttr('disabled');
            }
        });
    });
}

var passwordStrength = new function () {
    this.countRegexp = function (val, rex) {
        var match = val.match(rex);
        return match ? match.length : 0;
    };

    this.getStrength = function (val, minLength) {
        var len = val.length;

        // too short =(
        if (len < minLength) {
            return 0;
        }

        var nums = this.countRegexp(val, /\d/g),
        lowers = this.countRegexp(val, /[a-z]/g),
        uppers = this.countRegexp(val, /[A-Z]/g),
        specials = len - nums - lowers - uppers;

        // just one type of characters =(
        if (nums == len || lowers == len || uppers == len || specials == len) {
            return 1;
        }

        var strength = 0;
        if (nums) { strength += 2; }
        if (lowers) { strength += uppers ? 4 : 3; }
        if (uppers) { strength += lowers ? 4 : 3; }
        if (specials) { strength += 5; }
        if (len > 10) { strength += 1; }

        return strength;
    };

    this.getStrengthLevel = function (val, minLength) {
        var strength = this.getStrength(val, minLength);

        val = 1;
        if (strength <= 0) {
            val = 1;
        } else if (strength > 0 && strength <= 4) {
            val = 2;
        } else if (strength > 4 && strength <= 8) {
            val = 3;
        } else if (strength > 8 && strength <= 12) {
            val = 4;
        } else if (strength > 12) {
            val = 5;
        }

        return val;
    };
};
