$(document).ready(function () {
    $('form[dataconfirm]').submit(function () {
        return confirm($(this).attr('dataconfirm'));
    });
})
