$(document).ready(function () {
    $('#cphMain_txtbBeneficiary').autocomplete({
        source: 'UserHandler.ashx',
        minLength: 3
    })
});