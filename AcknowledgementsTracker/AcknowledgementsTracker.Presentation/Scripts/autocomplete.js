$(document).ready(function () {
    $('#cphMain_txtbBeneficiary').autocomplete({
        source: 'UserHandler.ashx',
        minLength: 3,

        // TODO: Refactor
        response: function (event, ui) {
            return {
                label: ui.item.split(':')[0],
                val: ui.item.split(':')[1]
            }
        },

        select: function (event, ui) {
            $("#cphMain_hfUserUsername").val(ui.item.val);
        }
    })
});