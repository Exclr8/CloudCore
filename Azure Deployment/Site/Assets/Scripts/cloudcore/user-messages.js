$(window).load(function () {

    $(document).on('click.bs.dropdown.data-api', '[data-toggle="collapse"]', function (e) {

        e.stopPropagation();

    });

    $(document).on('click', '.dropdown.message-area', function (e) {

        e.stopPropagation();

    });


    $(".expandable-link").click(function () {

        $(this).children(".glyphicon").toggleClass('glyphicon-flip');

    });

    $(".message-item").click(function () {

        $(this).children(".glyphicon").toggleClass('glyphicon-flip');

    });


    $(function () {

        $('[data-toggle="tooltip"]').tooltip()

    })

    $('.message-overlay').click(function () {

        if ($(".message-overlay").hasClass('show-overlay')) {

            $(".message-overlay").removeClass('show-overlay');

        }

    });

    $(document).on('click', '[data-toggle="modal"]', function () {

        if ($(".message-overlay").hasClass('show-overlay')) {

            $(".message-overlay").removeClass('show-overlay');

        }

    });

    $('a.menu-item-active').click(function () {

        if ($(".message-overlay").hasClass('show-overlay')) {

            $(".message-overlay").removeClass('show-overlay');

        }

    });

    $("#user-messages").click(function () {
        $(".message-overlay").toggleClass('show-overlay');
    });

    $('.dropdown-toggle').click(function () {
        var dropdownList = $('.dropdown-menu');
        var dropdownOffset = $(this).offset();
        var offsetLeft = dropdownOffset.left;
        var dropdownWidth = dropdownList.width();
        var docWidth = $(window).width();

        var subDropdown = $('.dropdown-menu').eq(1);
        var subDropdownWidth = subDropdown.width();

        var isDropdownVisible = (offsetLeft + dropdownWidth <= docWidth);
        var isSubDropdownVisible = (offsetLeft + dropdownWidth + subDropdownWidth <= docWidth);

        if (!isDropdownVisible || !isSubDropdownVisible) {
            $('.dropdown-menu').addClass('pull-right');
        } else {
            $('.dropdown-menu').removeClass('pull-right');
        }
    });
});
