$(document).ready(function () {
    $('select[name^="activity_"]').change(function () {
        if ($(this).attr("value") == '') {
            ShowError('You have a selected a sub-process please select an activity.');
            var optionLabel = $(this).children('option:first-child');
            optionLabel.attr("selected", "selected");
            var id = $(this).attr('id');
            $('#' + id + "-button .ui-selectmenu-status").html(optionLabel.html());
            return false;
        }
        else {
            var retStr = '[';

            $('form select[name^="activity_"]').each(function (index) {
                if (retStr != '[') {
                    retStr += ',';
                }

                var fromGuid = $(this).attr('id').replace('activity_', '');
                var toGuid = $(this).attr('value');

                if (toGuid == '') {
                    $(this).focus();
                    ShowError('Please select an activity.');
                    return false;
                }

                retStr += '{"FromActivityName":"", "FromActivityGuid":"' + fromGuid + '","ToActivityGuid":"' + toGuid + '", "SubProcessName":""}'
            });

            retStr += ']';

            $("#MigrationDataAsJson").val(retStr);
        }
    });

    $('form').submit(function () {
        var migrationString = $("#MigrationDataAsJson").val();

        if (migrationString.indexOf('"ToActivityGuid":"00000000-0000-0000-0000-000000000000"') > 0) {
            ShowError("Please select the activities you wish to migrate old worklist instances to.");
            return false;
        }
    });
});